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

        Task<FeatureModel> GetFeatureByCodeAsync(string featureCode);
        Task<string> AddFeatureAsync(FeatureModel featuretModel);
        Task UpdateFeatureAsync(string featureCode, FeatureModel featureModel);
        Task DeleteFeatureAsync(string featureCode);
    }
    
}
