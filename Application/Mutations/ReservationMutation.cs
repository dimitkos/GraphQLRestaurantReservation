using Application.Interfaces;
using Application.Types;
using Domain.Entities;
using GraphQL;
using GraphQL.Types;

namespace Application.Mutations
{
    public class ReservationMutation : ObjectGraphType
    {
        public ReservationMutation(IReservationRepository reservationRepository)
        {
            Field<ReservationType>("CreateReservation").Arguments(new QueryArguments(new QueryArgument<ReservationInputType> { Name = "reservation" }))
                .ResolveAsync(async (context) =>
                {
                    return await reservationRepository.AddReservation(context.GetArgument<Reservation>("reservation"));
                });
        }
    }
}
