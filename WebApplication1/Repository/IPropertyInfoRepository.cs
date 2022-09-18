using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IPropertyInfoRepository
    {
        Task<List<PropertyInfoModel>> GetAllPropertyInfosAsync();
        Task<PropertyInfoModel> GetPropertyInfoByIdAsync(int propertyId);
        Task<int> AddPropertyInfoAsync(PropertyInfoModel propertyInfoModel);
        Task UpdatePropertyInfoAsync(int propertyId, PropertyInfoModel propertyInfoModel);
        Task DeletePropertyInfoAsync(int propertyId);


    }
}
