using GraphQL.Types;
using GraphQLRestaurantReservation.Interfaces;
using GraphQLRestaurantReservation.Models;

namespace GraphQLRestaurantReservation.Type
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IMenuRepository menuRepository)
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.ImageUrl);

#warning impleme a handling one to many relationship
            Field<ListGraphType<MenuType>>("Menus").Resolve(context =>
            {
                return menuRepository.GetAllMenu();
            });
        }
    }
}
