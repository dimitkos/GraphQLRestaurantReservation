using GraphQLRestaurantReservation.Data;
using GraphQLRestaurantReservation.Interfaces;
using GraphQLRestaurantReservation.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLRestaurantReservation.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GraphQLDbContext _context;

        public CategoryRepository(GraphQLDbContext context)
        {
            _context = context;
        }

        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        public void DeleteCategory(int id)
        {
            var categoryResult = _context.Categories.Find(id);

            if (categoryResult is null)
                return;

            _context.Categories.Remove(categoryResult);
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category UpdateCategory(int id, Category category)
        {
            var categoryResult = _context.Categories.Find(id);

            if (categoryResult is null)
                return new Category();

            categoryResult.Name = category.Name;
            categoryResult.ImageUrl = category.ImageUrl;
            _context.SaveChanges();

            return category;
        }
    }
}
