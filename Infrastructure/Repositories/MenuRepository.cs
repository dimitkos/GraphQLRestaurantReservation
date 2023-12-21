using Application.Interfaces;
using Domain.Entities;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly GraphQLDbContext _context;

        public MenuRepository(GraphQLDbContext context)
        {
            _context = context;
        }

        public async Task<Menu> AddMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            return menu;
        }

        public async Task DeleteMenu(int id)
        {
            var menuResult = await _context.Menus.FindAsync(id);

            if (menuResult is null)
                return;

            _context.Menus.Remove(menuResult);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Menu>> GetAllMenu()
        {
            return await _context.Menus.ToListAsync();
        }

        public async Task<Menu> GetMenuById(int id)
        {
            return await _context.Menus.FindAsync(id) ?? new Menu();
        }

        public async Task<Menu> UpdateMenu(int id, Menu menu)
        {
            var menuResult = await _context.Menus.FindAsync(id);

            if (menuResult is null)
                return new Menu();

            menuResult.Name = menu.Name;
            menuResult.Description = menu.Description;
            await _context.SaveChangesAsync();

            return menu;
        }
    }
}
