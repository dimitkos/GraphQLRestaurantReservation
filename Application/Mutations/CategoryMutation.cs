using Application.Interfaces;
using Application.Types;
using Domain.Entities;
using GraphQL;
using GraphQL.Types;

namespace Application.Mutations
{
    public class CategoryMutation : ObjectGraphType
    {
        public CategoryMutation(ICategoryRepository categoryRepository)
        {
            Field<CategoryType>("CreateCategory").Arguments(new QueryArguments(new QueryArgument<CategoryInputType> { Name = "category" })).ResolveAsync(async (context) =>
            {
                return await categoryRepository.AddCategory(context.GetArgument<Category>("category"));
            });

            Field<CategoryType>("UpdateCategory").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" },
                new QueryArgument<CategoryInputType> { Name = "category" })).ResolveAsync(async (context) =>
                {
                    var category = context.GetArgument<Category>("category");
                    var categoryId = context.GetArgument<int>("categoryId");
                    return await categoryRepository.UpdateCategory(categoryId, category);
                });

            Field<StringGraphType>("DeleteCategory").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" })).ResolveAsync(async (context) =>
            {

                var categoryId = context.GetArgument<int>("categoryId");
                await categoryRepository.DeleteCategory(categoryId);
                return "The category against this Id" + categoryId + "has been deleted";
            });
        }
    }
}
