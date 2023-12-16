using GraphQLRestaurantReservation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLRestaurantReservation.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservations();
        Reservation AddReservation(Reservation reservation);
    }
}
