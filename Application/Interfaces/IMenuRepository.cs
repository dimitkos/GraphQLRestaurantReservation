using Domain.Entities;

namespace Application.Interfaces
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
