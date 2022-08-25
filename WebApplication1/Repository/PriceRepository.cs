using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{

   
    public class PriceRepository : IPriceRepository
    {
        private readonly MyContext _context;

        public PriceRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<PriceModel>> GetAllPricesAsync()
        {
            var records = await _context.Prices.Select(x => new PriceModel()
            {
                PriceId = x.PriceId,
                Code = x.Code,
                CurrentPrice= x.CurrentPrice  

            }).ToListAsync();

            return records;
        }


        public async Task<PriceModel> GetPriceByIdAsync(int priceId)
        {
            var records = await _context.Prices.Where(x => x.PriceId == priceId).Select(x => new PriceModel()
            {

                PriceId = x.PriceId,
                Code = x.Code,
                CurrentPrice = x.CurrentPrice

            }).FirstOrDefaultAsync();

            return records;
        }



        public async Task<int> AddPriceAsync(PriceModel priceModel)
        {

            var price = new Prices()
            {
                PriceId = priceModel.PriceId,
                Code = priceModel.Code,
                CurrentPrice = priceModel.CurrentPrice

            };

            _context.Prices.Add(price);
            await _context.SaveChangesAsync();

            return price.PriceId;
        }



        public async Task UpdatePriceAsync(int priceId, PriceModel priceModel)
        {
            var price = await _context.Prices.FindAsync(priceId);

            if (price != null)
            {
                
                price.PriceId = priceModel.PriceId;
                price.Code = priceModel.Code;
                price.CurrentPrice = priceModel.CurrentPrice;

                await _context.SaveChangesAsync();
            }





        }


        public async Task DeletePriceAsync(int priceId)
        {

            var price = new Prices() { PriceId = priceId };

            _context.Prices.Remove(price);
            await _context.SaveChangesAsync();


        }
    }
    
}
