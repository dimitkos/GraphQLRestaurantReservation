using GraphQLRestaurantReservation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLRestaurantReservation.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(int id, Category category);
        Task DeleteCategory(int id);
    }
}
