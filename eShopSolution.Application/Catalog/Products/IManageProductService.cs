
using EShopSolution.ViewModels.Catalog;
using EShopSolution.ViewModels.Catalog.Commons;
using EShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);// Lấy yêu cầu và trả về maSP vừa tạo

        Task<bool> UpdatePrice(int productId, decimal NewPrice);

        Task AddViewCount(int productId);
        Task<bool> UpdateStock(int productId, int addedQuantity); 
        Task<int>  Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);
        // Sử dụng generic, bên trong ProductViewModel sẽ trả về 1 list item
        Task<PagedResult< ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, List<IFormFile> files);
        Task<int> RemoveImages(int imageId, List<IFormFile> files);
        Task<int> UpdateImage(int imageId, string caption, bool isDefault);
        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
