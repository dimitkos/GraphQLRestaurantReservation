using GraphQL.Types;
using GraphQLRestaurantReservation.Interfaces;
using GraphQLRestaurantReservation.Type;

namespace GraphQLRestaurantReservation.Query
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
