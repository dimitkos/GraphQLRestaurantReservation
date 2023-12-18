using Application.Interfaces;
using Application.Types;
using Domain.Entities;
using GraphQL;
using GraphQL.Types;

namespace Application.Mutations
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenuRepository menuRepository)
        {
            Field<MenuType>("CreateMenu")
                .Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" }))
                .ResolveAsync(async (context) =>
                {
                    return await menuRepository.AddMenu(context.GetArgument<Menu>("menu"));
                });

            Field<MenuType>("UpdateMenu")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }, new QueryArgument<MenuInputType> { Name = "menu" }))
                .ResolveAsync(async (context) =>
                {
                    var menu = context.GetArgument<Menu>("menu");
                    var menuId = context.GetArgument<int>("menuId");

                    return await menuRepository.UpdateMenu(menuId, menu);
                });

            Field<StringGraphType>("DeleteMenu")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }))
                .ResolveAsync(async (context) =>
                {
                    var menuId = context.GetArgument<int>("menuId");
                    await menuRepository.DeleteMenu(menuId);

                    return $"The menu with id {menuId} is deleted";
                });
        }
    }
}
