using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using eShopSolution.Application.Dtos;
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
        Task<List<ProductViewModel>> GetAll();
        // Sử dụng generic, bên trong ProductViewModel sẽ trả về 1 list item
        Task<PagedResult< ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}
