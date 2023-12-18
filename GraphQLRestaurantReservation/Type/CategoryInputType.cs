using GraphQL.Types;

namespace GraphQLRestaurantReservation.Type
{
    public class CategoryInputType : InputObjectGraphType
    {
        public CategoryInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("imageurl");
        }
    }
}
