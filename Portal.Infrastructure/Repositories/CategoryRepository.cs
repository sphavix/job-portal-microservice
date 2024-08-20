
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Domain.Repositories;
using Portal.Infrastructure.Persistance;

namespace Portal.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PortalDbContext _context;
        public CategoryRepository(PortalDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryAsync(Guid id)
        {
            var category = await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync().ConfigureAwait(true);
            return category!;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            var entity = await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return entity.Entity;
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var category = await GetCategoryAsync(id);
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync().ConfigureAwait(true) > 0;
        }
    }
}