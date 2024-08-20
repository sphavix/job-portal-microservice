
using Portal.Domain.Entities;

namespace Portal.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(Guid id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(Guid id);
    }
}