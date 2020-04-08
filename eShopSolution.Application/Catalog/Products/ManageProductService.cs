
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EShopSolution.ViewModels.Catalog.Commons;
using EShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using eShopSolution.Application.Common;
using EShopSolution.ViewModels.Catalog;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;// biến tạm nê chỉ đọc
        private readonly IStorageService _storageService;
        public ManageProductService(EShopDbContext context,IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public  Task<int> AddImage(int productId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        // Tạo 1 Contructor cho product
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTransactions=new List<ProductTransaction>()
                {
                    // thêm theo dạng cha con
                    new ProductTransaction
                    {
                        Name=request.Name,
                        Description=request.Description,
                        Details=request.Details,
                        SeoDescription=request.SeoDescription,
                        SeoAlias=request.SeoAlias,
                        SeoTitle=request.SeoTitle,
                        LanguageId=request.LanguageId
                    }
                }
            };
            // Save image
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption= "Thumbnail image",
                        DateCreated=DateTime.Now,
                        FileSize=request.ThumbnailImage.Length,
                        ImagePath=await this.SaveFile(request.ThumbnailImage),
                        IsDefault=true,
                        SortOrder=1
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new EShopException($"Cannot find a product: {productId}");
            }
            var images = _context.ProductImages.Where(i => i.ProductId == productId);
           foreach(var image in images)
           {
                await _storageService.DeleteFileAsync(image.ImagePath);
           }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        // Search
        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {// 1. Select join
            var query = from p in _context.Products
                        join pt in _context.ProductTransactions on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p,pt,pic};
            // 2.Filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            if (request.CategoryId.Count > 0)
            {
                query = query.Where(x => request.CategoryId.Contains(x.pic.CategoryId));
            }
            // 3. Paging
            int totalRow = await query.CountAsync();
            // gọi biến data chứa query = pa
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x=>new ProductViewModel() {
                    Id= x.p.Id,
                    Name=x.pt.Name,
                    DateCreated=x.p.DateCreated,
                    Description=x.pt.Description,
                    Details=x.pt.Details,
                    LanguageId=x.pt.LanguageId,
                    OriginalPrice=x.p.OriginalPrice,
                    Price=x.p.Price,
                    SeoAlias=x.pt.SeoAlias,
                    SeoDescription=x.pt.SeoDescription,
                    SeoTitle=x.pt.SeoTitle,
                    Stock=x.p.Stock,
                    ViewCount=x.p.ViewCount
                }).ToListAsync();
            // 4. Select Projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = await data
            };
            return pagedResult;
        }

        public Task<PagedResult<ProductViewModel>> GetAllPaging(GetPublicProductPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImages(int imageId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            // Đầu tiên query ra product: để tìm kiếm Id sản phẩm
            var product = await _context.Products.FindAsync(request.Id);
            // tạo ra query Transactons: trả về phần tử không đồng bộ đầu tiên thỏa mãn điều kiện
            // và lấy ra languageId với phương thức request
            var productTransactions = await _context.ProductTransactions.FirstOrDefaultAsync(x => x.ProductId == request.Id
            && x.LanguageId == request.LanguageId);
            if (product == null||productTransactions==null)
            {
                throw new EShopException($"Cannot find a product with id: {product.Id}");
            }
            // Lấy ra 1 danh sách gồm các ptử
            productTransactions.Name = request.Name;
            productTransactions.SeoAlias = request.SeoAlias;
            productTransactions.SeoDescription = request.SeoDescription;
            productTransactions.SeoTitle = request.SeoTitle;
            productTransactions.Description = request.Description;
            productTransactions.Details = request.Details;
            // Save Image
            if (request.ThumbnailImage != null)
            {
                // ta sẽ kiểm tra
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    thumbnailImage.SortOrder = 1;
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            // Sau đó lưu thay đổi
            return await _context.SaveChangesAsync();
            // Sau đó sẽ trả về kiểu int đã được update
            // if > 0 là update thành công

        }

        public Task<int> UpdateImage(int imageId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePrice(int ProductId, decimal NewPrice)
        {
            // đầu tiên tạo 1 biến product để lấy ProductId 
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null)
            {
                throw new EShopException($"Cannot find a product with id: {product.Id}");
            }
            // gán product.Price ới lấy ra cho NewPrice
            product.Price = NewPrice;
            // sau đó trả thay đổi kiểu int về kiểu bool là: >0;
            return await _context.SaveChangesAsync()>0 ;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new EShopException($"Cannot find a product with id: {product.Id}");
            }
            // gán gtrị stock vừa lấy ra vào addedQuantity 
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var OriginalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(OriginalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }


        
    }
}
