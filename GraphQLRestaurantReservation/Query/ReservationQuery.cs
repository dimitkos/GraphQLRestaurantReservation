using GraphQL.Types;
using GraphQLRestaurantReservation.Interfaces;
using GraphQLRestaurantReservation.Type;

namespace GraphQLRestaurantReservation.Query
{
    public class ReservationQuery : ObjectGraphType
    {
        //public ReservationQuery(IReservationRepository reservationRepository)
        //{
        //    Field<ListGraphType<ReservationType>>("Reservations").Resolve(context =>
        //    {
        //        return reservationRepository.GetReservations();
        //    });
        //}

        public ReservationQuery(IReservationRepository reservationRepository)
        {
            FieldAsync<ListGraphType<ReservationType>>("posts",
            resolve: async (context) => await reservationRepository.GetReservations());
        }
    }
}
