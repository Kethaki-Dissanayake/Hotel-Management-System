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
    public class RoomTypesController : ControllerBase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypesController(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }




        [HttpGet("")]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            var roomTypes = await _roomTypeRepository.GetAllRoomTypesAsync();
            return Ok(roomTypes);

        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomTypeById([FromRoute] int id)
        {
            var roomType = await _roomTypeRepository.GetRoomTypeByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }


            return Ok(roomType);

        }



        [HttpPost("")]
        public async Task<IActionResult> AddNewRoomType([FromBody] RoomTypeModel roomTypeModel)
        {
            var id = await _roomTypeRepository.AddRoomTypeAsync(roomTypeModel);
            return CreatedAtAction(nameof(GetRoomTypeById), new { id = id, controller = "roomTypes" }, id);

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoomType([FromBody] RoomTypeModel roomTypeModel, [FromRoute] int id)
        {
            await _roomTypeRepository.UpdateRoomTypeAsync(id, roomTypeModel);
            return Ok();

        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> RoomTypeFeature([FromRoute] int id)
        {
            await _roomTypeRepository.DeleteRoomTypeAsync(id);
            return Ok();

        }
    }
}
