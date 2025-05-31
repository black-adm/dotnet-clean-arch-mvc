using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int? id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<Category> RemoveCategoryAsync(Category category);
    }
}