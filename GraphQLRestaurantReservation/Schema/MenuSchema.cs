using GraphQLRestaurantReservation.Mutation;
using GraphQLRestaurantReservation.Query;

namespace GraphQLRestaurantReservation.Schema
{
    public class MenuSchema : GraphQL.Types.Schema
    {
        public MenuSchema(MenuQuery menuQuery, MenuMutation menuMutation)
        {
            Query = menuQuery;
            Mutation = menuMutation;
        }
    }
}
