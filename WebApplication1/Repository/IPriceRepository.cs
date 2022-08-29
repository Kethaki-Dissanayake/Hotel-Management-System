using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;


namespace WebApplication1.Repository
{
    public interface IPriceRepository
    {
        Task<List<PriceModel>> GetAllPricesAsync();
        Task<PriceModel> GetPriceByIdAsync(int priceId);
        Task<int> AddPriceAsync(PriceModel priceModel);
        Task UpdatePriceAsync(int priceId, PriceModel priceModel);
        Task DeletePriceAsync(int priceId);
    }
    
}
