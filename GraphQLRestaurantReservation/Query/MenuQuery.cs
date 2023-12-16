using GraphQL;
using GraphQL.Types;
using GraphQLRestaurantReservation.Interfaces;
using GraphQLRestaurantReservation.Type;

namespace GraphQLRestaurantReservation.Query
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenuRepository menuRepository) 
        {
            Field<ListGraphType<MenuType>>("Menus").Resolve(context => 
            {
                return menuRepository.GetAllMenu();
            });

            Field<MenuType>("Menu")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId"}))
                .Resolve(context =>
                {
                    return menuRepository.GetMenuById(context.GetArgument<int>("menuId"));
                });
        }
    }
}
