using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int? id);
        Task<Product> GetProductCategoryAsync(int? categoryId);
        Task<Product> CreateProductAsync(Product category);
        Task<Product> UpdateProductAsync(Product category);
        Task<Product> RemoveProductAsync(Product category);
    }
}