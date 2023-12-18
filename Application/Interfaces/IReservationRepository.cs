using Domain.Entities;

namespace Application.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservations();
        Task<Reservation> AddReservation(Reservation reservation);
    }
}
