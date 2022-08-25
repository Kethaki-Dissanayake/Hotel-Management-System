using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;


namespace WebApplication1.Repository
{
    public interface IFeatureRepository
    {
        
        Task<List<FeatureModel>> GetAllFeaturesAsync();

        Task<FeatureModel> GetFeatureByIdAsync(int featureId);
        Task<int> AddFeatureAsync(FeatureModel featuretModel);
        Task UpdateFeatureAsync(int featureId, FeatureModel featureModel);
        Task DeleteFeatureAsync(int featureId);
    }
    
}
