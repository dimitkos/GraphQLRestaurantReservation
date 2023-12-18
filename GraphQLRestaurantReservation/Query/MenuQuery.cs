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
            Field<ListGraphType<MenuType>>("Menus").ResolveAsync(async (context) => 
            {
                return await menuRepository.GetAllMenu();
            });

            Field<MenuType>("Menu")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId"}))
                .ResolveAsync(async (context) =>
                {
                    return await menuRepository.GetMenuById(context.GetArgument<int>("menuId"));
                });
        }
    }
}
