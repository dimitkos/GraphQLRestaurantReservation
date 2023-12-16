using GraphQLRestaurantReservation.Data;
using GraphQLRestaurantReservation.Interfaces;
using GraphQLRestaurantReservation.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLRestaurantReservation.Services
{
#warning make them async
    public class MenuRepository : IMenuRepository
    {
        private readonly GraphQLDbContext _context;

        public MenuRepository(GraphQLDbContext context)
        {
            _context = context;
        }

        public Menu AddMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();

            return menu;
        }

        public void DeleteMenu(int id)
        {
            var menuResult = _context.Menus.Find(id);

            if (menuResult is null)
                return;

            _context.Menus.Remove(menuResult);
            _context.SaveChanges();
        }

        public List<Menu> GetAllMenu()
        {
            return _context.Menus.ToList();
        }

        public Menu GetMenuById(int id)
        {
            return _context.Menus.Find(id) ?? new Menu();
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            var menuResult = _context.Menus.Find(id);

            if (menuResult is null)
                return new Menu();

            menuResult.Name = menu.Name;
            menuResult.Description = menu.Description;
            _context.SaveChanges();

            return menu;
        }
    }
}
