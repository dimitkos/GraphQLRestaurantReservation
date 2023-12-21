using Application.Interfaces;
using Application.Types;
using GraphQL.Types;

namespace Application.Queries
{
    public class CategoryQuery : ObjectGraphType
    {
        public CategoryQuery(ICategoryRepository categoryRepository)
        {
            Field<ListGraphType<CategoryType>>("Categories").ResolveAsync(async (context) =>
            {
                return await categoryRepository.GetCategories();
            });
        }
    }
}
