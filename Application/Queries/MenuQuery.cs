using Application.Interfaces;
using Application.Types;
using GraphQL;
using GraphQL.Types;

namespace Application.Queries
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
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }))
                .ResolveAsync(async (context) =>
                {
                    return await menuRepository.GetMenuById(context.GetArgument<int>("menuId"));
                });
        }
    }
}
