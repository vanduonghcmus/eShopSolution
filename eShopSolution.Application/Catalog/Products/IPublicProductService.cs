
using EShopSolution.ViewModels.Catalog.Commons;
using EShopSolution.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService // Chứa các phương thức bên ngoài 
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetManageProductPagingRequest request);
    }
}
