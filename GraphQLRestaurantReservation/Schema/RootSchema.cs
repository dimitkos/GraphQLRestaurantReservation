using GraphQLRestaurantReservation.Query;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQLRestaurantReservation.Schema
{
    public class RootSchema : GraphQL.Types.Schema
    {
        public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();  
        }
    }
}
