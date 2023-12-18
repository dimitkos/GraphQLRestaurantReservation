using Application.Interfaces;
using Domain.Entities;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GraphQLDbContext _context;

        public CategoryRepository(GraphQLDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task DeleteCategory(int id)
        {
            var categoryResult = await _context.Categories.FindAsync(id);

            if (categoryResult is null)
                return;

            _context.Categories.Remove(categoryResult);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> UpdateCategory(int id, Category category)
        {
            var categoryResult = await _context.Categories.FindAsync(id);

            if (categoryResult is null)
                return new Category();

            categoryResult.Name = category.Name;
            categoryResult.ImageUrl = category.ImageUrl;
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
