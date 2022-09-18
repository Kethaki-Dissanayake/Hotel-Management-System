using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly MyContext _context;

        public ReservationRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<ReservationModel>> GetAllReservationsAsync()
        {
            var records = await _context.Reservations.Select(x => new ReservationModel()
            {
                ReservationId = x.ReservationId,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                TotalDays = x.TotalDays

            }).ToListAsync();

            return records;
        }


        public async Task<ReservationModel> GetReservationByIdAsync(int reservationId)
        {
            var records = await _context.Reservations.Where(x => x.ReservationId == reservationId).Select(x => new ReservationModel()
            {
                ReservationId = x.ReservationId,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                TotalDays = x.TotalDays

            }).FirstOrDefaultAsync();

            return records;
        }



        public async Task<int> AddReservationAsync(ReservationModel reservationModel)
        {

            var reservation = new Reservations()
            {
                ReservationId = reservationModel.ReservationId,
                CheckIn = reservationModel.CheckIn,
                CheckOut = reservationModel.CheckOut,
                TotalDays = reservationModel.TotalDays

            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return reservation.ReservationId;
        }



        public async Task UpdateReservationAsync(int reservationId, ReservationModel reservationModel)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);

            if (reservation != null)
            {
                reservation.ReservationId = reservationModel.ReservationId;
                reservation.CheckIn = reservationModel.CheckIn;
                reservation.CheckOut = reservationModel.CheckOut;
                reservation.TotalDays = reservationModel.TotalDays;

                await _context.SaveChangesAsync();
            }





        }


        public async Task DeleteReservationAsync(int reservationId)
        {

            var reservation = new Reservations() { ReservationId = reservationId };

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();


        }
    }
}
