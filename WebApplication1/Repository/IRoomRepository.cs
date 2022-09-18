using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IRoomRepository
    {
        Task<List<RoomModel>> GetAllRoomsAsync();
        Task<RoomModel> GetRoomByIdAsync(int roomId);
        Task<int> AddRoomAsync(RoomModel roomModel);
        Task UpdateRoomAsync(int roomId, RoomModel roomModel);
        Task DeleteRoomAsync(int roomId);

    }
}
