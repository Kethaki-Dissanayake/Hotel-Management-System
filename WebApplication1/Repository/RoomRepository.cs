using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyContext _context;

        public RoomRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<RoomModel>> GetAllRoomsAsync()
        {
            var records = await _context.Rooms.Select(x => new RoomModel()
            {
                RoomId = x.RoomId,
                Name = x.Name
                
            }).ToListAsync();

            return records;
        }


        public async Task<RoomModel> GetRoomByIdAsync(int roomId)
        {
            var records = await _context.Rooms.Where(x => x.RoomId == roomId).Select(x => new RoomModel()
            {

                RoomId = x.RoomId,
                Name = x.Name

            }).FirstOrDefaultAsync();

            return records;
        }



        public async Task<int> AddRoomAsync(RoomModel roomModel)
        {

            var room = new Rooms()
            {
                RoomId = roomModel.RoomId,
                Name = roomModel.Name

            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return room.RoomId;
        }



        public async Task UpdateRoomAsync(int roomId, RoomModel roomModel)
        {
            var room = await _context.Rooms.FindAsync(roomId);

            if (room != null)
            {

                room.RoomId = roomModel.RoomId;
                room.Name = roomModel.Name;

                await _context.SaveChangesAsync();
            }





        }


        public async Task DeleteRoomAsync(int roomId)
        {

            var room = new Rooms() { RoomId = roomId };

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();


        }
    }
}
