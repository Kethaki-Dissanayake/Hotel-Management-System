using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IReservationRepository
    {

        Task<List<ReservationModel>> GetAllReservationsAsync();
        Task<ReservationModel> GetReservationByIdAsync(int reservationId);
        Task<int> AddReservationAsync(ReservationModel reservationModel);
        Task UpdateReservationAsync(int reservationId, ReservationModel reservationModel);
        Task DeleteReservationAsync(int reservationId);

    }
}
