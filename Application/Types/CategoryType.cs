using Application.Interfaces;
using Domain.Entities;
using GraphQL.Types;

namespace Application.Types
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IMenuRepository menuRepository)
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.ImageUrl);

#warning impleme a handling one to many relationship
            Field<ListGraphType<MenuType>>("Menus").ResolveAsync(async (context) =>
            {
                return await menuRepository.GetAllMenu();
            });
        }
    }
}
