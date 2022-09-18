using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{

   
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly MyContext _context;

        public RoomTypeRepository(MyContext context)
        {
            _context = context;
        }



        //Getiing the List of Room Types
        public async Task<List<RoomTypeModel>> GetAllRoomTypesAsync()
        {
            var records = await _context.RoomTypes.Select(x => new RoomTypeModel()
            {
                RoomTypeId = x.RoomTypeId,
                Name = x.Name,
                Description= x.Description  

            }).ToListAsync();

            return records;
        }


        //Getting the Room type by Id
        public async Task<RoomTypeModel> GetRoomTypeByIdAsync(int roomTypeId)
        {
            var records = await _context.RoomTypes.Where(x => x.RoomTypeId == roomTypeId).Select(x => new RoomTypeModel()
            {

                RoomTypeId = x.RoomTypeId,
                Name = x.Name,
                Description = x.Description

            }).FirstOrDefaultAsync();

            return records;
        }



        //Creating New Room Type
        public async Task<int> AddRoomTypeAsync(RoomTypeModel roomTypeModel)
        {

            var roomType = new RoomTypes()
            {
                RoomTypeId = roomTypeModel.RoomTypeId,
                Name = roomTypeModel.Name,
                Description = roomTypeModel.Description
            };

            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();

            return roomType.RoomTypeId;
        }


        //Upadating Roomtype

        public async Task UpdateRoomTypeAsync(int roomTypeId, RoomTypeModel roomTypeModel)
        {
            var roomType = await _context.RoomTypes.FindAsync(roomTypeId);

            if (roomType != null)
            {

                roomType.RoomTypeId = roomTypeModel.RoomTypeId;
                roomType.Name = roomTypeModel.Name;
                roomType.Description = roomTypeModel.Description;

                await _context.SaveChangesAsync();
            }





        }


        //Deleting a Roomtype
        public async Task DeleteRoomTypeAsync(int roomTypeId)
        {

            var roomType = new RoomTypes() { RoomTypeId = roomTypeId };

            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();


        }
    }
    
}
