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
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }




        [HttpGet("")]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomRepository.GetAllRoomsAsync();
            return Ok(rooms);

        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById([FromRoute] int id)
        {
            var room = await _roomRepository.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }


            return Ok(room);

        }



        [HttpPost("")]
        public async Task<IActionResult> AddNewRoom([FromBody] RoomModel roomModel)
        {
            var id = await _roomRepository.AddRoomAsync(roomModel);
            return CreatedAtAction(nameof(GetRoomById), new { id = id, controller = "rooms" }, id);

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrice([FromBody] RoomModel roomModel, [FromRoute] int id)
        {
            await _roomRepository.UpdateRoomAsync(id, roomModel);
            return Ok();

        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> RoomFeature([FromRoute] int id)
        {
            await _roomRepository.DeleteRoomAsync(id);
            return Ok();

        }
    }
}

