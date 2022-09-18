using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationsController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }




        [HttpGet("")]
        public async Task<IActionResult> GetAllReservation()
        {
            var reservations = await _reservationRepository.GetAllReservationsAsync();
            return Ok(reservations);

        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById([FromRoute] int id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }


            return Ok(reservation);

        }



        [HttpPost("")]
        public async Task<IActionResult> AddNewReservation([FromBody] ReservationModel reservationModel)
        {
            var id = await _reservationRepository.AddReservationAsync(reservationModel);
            return CreatedAtAction(nameof(GetReservationById), new { id = id, controller = "reservations" }, id);

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation([FromBody] ReservationModel reservationModel, [FromRoute] int id)
        {
            await _reservationRepository.UpdateReservationAsync(id, reservationModel);
            return Ok();

        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] int id)
        {
            await _reservationRepository.DeleteReservationAsync(id);
            return Ok();

        }
    }
}

