using GraphQLRestaurantReservation.Data;
using GraphQLRestaurantReservation.Interfaces;
using GraphQLRestaurantReservation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLRestaurantReservation.Services
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
