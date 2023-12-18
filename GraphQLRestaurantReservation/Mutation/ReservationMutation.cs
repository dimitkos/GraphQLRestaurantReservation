using GraphQL;
using GraphQL.Types;
using GraphQLRestaurantReservation.Interfaces;
using GraphQLRestaurantReservation.Models;
using GraphQLRestaurantReservation.Type;

namespace GraphQLRestaurantReservation.Mutation
{
    public class ReservationMutation : ObjectGraphType
    {
        public ReservationMutation(IReservationRepository reservationRepository)
        {
            Field<ReservationType>("CreateReservation").Arguments(new QueryArguments(new QueryArgument<ReservationInputType> { Name = "reservation" })).Resolve(context =>
            {
                return reservationRepository.AddReservation(context.GetArgument<Reservation>("reservation"));
            });
        }
    }
}
