using eShopSolution.Application.Catalog.Products.Dtos;
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

        Task<int>  Update(ProductEditRequest request);

        Task<int> Delete(int ProductId);
        Task<List<ProductViewModel>> GetAll();
        // Sử dụng generic, bên trong ProductViewModel sẽ trả về 1 list item
        Task<PagedViewModel< ProductViewModel>> GetAllPaging(string keywork, int pageIndex, int pageSize);
    }
}
