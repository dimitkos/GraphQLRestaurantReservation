using GraphQL.Types;
using GraphQLRestaurantReservation.Interfaces;
using GraphQLRestaurantReservation.Services;
using GraphQLRestaurantReservation.Type;

namespace GraphQLRestaurantReservation.Query
{
    public class ReservationQuery : ObjectGraphType
    {
        public ReservationQuery(IReservationRepository reservationRepository)
        {
            Field<ListGraphType<ReservationType>>("Reservations")
             .ResolveAsync(async (context) => await reservationRepository.GetReservations());
        }
    }
}
