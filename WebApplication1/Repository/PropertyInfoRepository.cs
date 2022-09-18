using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class PropertyInfoRepository : IPropertyInfoRepository
    {
        private readonly MyContext _context;

        public PropertyInfoRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<PropertyInfoModel>> GetAllPropertyInfosAsync()
        {
            var records = await _context.PropertyInfos.Select(x => new PropertyInfoModel()
            {
                PropertyId = x.PropertyId,
                Name = x.Name

            }).ToListAsync();

            return records;
        }


        public async Task<PropertyInfoModel> GetPropertyInfoByIdAsync(int propertyId)
        {
            var records = await _context.PropertyInfos.Where(x => x.PropertyId == propertyId).Select(x => new PropertyInfoModel()
            {

                PropertyId = x.PropertyId,
                Name = x.Name

            }).FirstOrDefaultAsync();

            return records;
        }



        public async Task<int> AddPropertyInfoAsync(PropertyInfoModel propertyInfoModel)
        {

            var propertyInfo = new PropertyInfos()
            {
               
                PropertyId = propertyInfoModel.PropertyId,
                Name = propertyInfoModel.Name

            };

            _context.PropertyInfos.Add(propertyInfo);
            await _context.SaveChangesAsync();

            return propertyInfo.PropertyId;
        }



        public async Task UpdatePropertyInfoAsync(int propertyId, PropertyInfoModel propertyInfoModel)
        {
            var propertyInfo = await _context.PropertyInfos.FindAsync(propertyId);

            if (propertyInfo != null)
            {
                propertyInfo.PropertyId = propertyInfoModel.PropertyId;
                propertyInfo.Name = propertyInfoModel.Name;


                await _context.SaveChangesAsync();
            }





        }


        public async Task DeletePropertyInfoAsync(int propertyId)
        {

            var propertyInfo = new PropertyInfos() { PropertyId = propertyId };

            _context.PropertyInfos.Remove(propertyInfo);
            await _context.SaveChangesAsync();


        }
    }
}
