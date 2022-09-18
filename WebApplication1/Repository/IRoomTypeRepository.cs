using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;


namespace WebApplication1.Repository
{
    public interface IRoomTypeRepository
    {
        Task<List<RoomTypeModel>> GetAllRoomTypesAsync();

        Task<RoomTypeModel> GetRoomTypeByIdAsync(int roomTypeId);
        Task<int> AddRoomTypeAsync(RoomTypeModel roomTypeModel);
        Task UpdateRoomTypeAsync(int roomTypeId, RoomTypeModel roomTypeModel);
        Task DeleteRoomTypeAsync(int roomTypeId);

    }
    
}
