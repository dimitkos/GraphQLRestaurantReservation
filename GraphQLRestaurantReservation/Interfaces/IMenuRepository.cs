using GraphQLRestaurantReservation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLRestaurantReservation.Interfaces
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllMenu();
        Task<Menu> GetMenuById(int id);
        Task<Menu> AddMenu(Menu menu);
        Task<Menu> UpdateMenu(int id, Menu menu);
        Task DeleteMenu(int id);
    }
}
