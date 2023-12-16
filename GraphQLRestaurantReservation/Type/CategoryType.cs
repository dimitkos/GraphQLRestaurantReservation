using GraphQL.Types;
using GraphQLRestaurantReservation.Models;

namespace GraphQLRestaurantReservation.Type
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.ImageUrl);
        }
    }
}
