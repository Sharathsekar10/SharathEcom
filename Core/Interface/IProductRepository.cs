using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);

        Task<IReadOnlyList<Product>> GetAllProduct();

        Task<IReadOnlyList<ProductBrand>> GetProductBrands();

        Task<IReadOnlyList<ProductType>> GetProductTypes();
    }
}