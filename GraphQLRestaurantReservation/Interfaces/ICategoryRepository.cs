using GraphQLRestaurantReservation.Models;
using System.Collections.Generic;

namespace GraphQLRestaurantReservation.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category AddCategory(Category category);
        Category UpdateCategory(int id, Category category);
        void DeleteCategory(int id);
    }
}
