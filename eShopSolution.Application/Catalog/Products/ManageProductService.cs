using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;// biến tạm nê chỉ đọc
        public ManageProductService(EShopDbContext context)
        {
            _context = context;
        }
        // Tạo 1 Contructor cho product
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int ProductId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keywork, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductEditRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
