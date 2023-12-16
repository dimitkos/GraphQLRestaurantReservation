using GraphQLRestaurantReservation.Models;
using System.Collections.Generic;

namespace GraphQLRestaurantReservation.Interfaces
{
    public interface IMenuRepository
    {
        List<Menu> GetAllMenu();
        Menu GetMenuById(int id);
        Menu AddMenu(Menu menu);
        Menu UpdateMenu(int id, Menu menu);
        void DeleteMenu(int id);
    }
}
