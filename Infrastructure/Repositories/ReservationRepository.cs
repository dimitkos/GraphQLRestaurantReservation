using Application.Interfaces;
using Domain.Entities;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly GraphQLDbContext _context;

        public ReservationRepository(GraphQLDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation> AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<List<Reservation>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }
    }
}
