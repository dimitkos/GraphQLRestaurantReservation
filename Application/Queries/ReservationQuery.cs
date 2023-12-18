using Application.Interfaces;
using Application.Types;
using GraphQL.Types;

namespace Application.Queries
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
