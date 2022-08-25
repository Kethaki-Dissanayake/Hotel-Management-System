using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{

   
    public class FeatureRepository : IFeatureRepository
    {
        private readonly MyContext _context;

        public FeatureRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<List<FeatureModel>> GetAllFeaturesAsync()
        {
            var records = await _context.Features.Select(x => new FeatureModel()
            {
                FeatureId = x.FeatureId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description
                

            }).ToListAsync();

            return records;
        }

        public async Task<FeatureModel> GetFeatureByIdAsync(int featureId)
        {
            var records = await _context.Features.Where(x => x.FeatureId == featureId).Select(x => new FeatureModel()
            {
                FeatureId= x.FeatureId,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description

            }).FirstOrDefaultAsync();

            return records;
        }

        public async Task<int> AddFeatureAsync(FeatureModel featuretModel)
        {

            var feature = new Features()
            {
                FeatureId = featuretModel.FeatureId,
                Code = featuretModel.Code,
                Name = featuretModel.Name,
                Description = featuretModel.Description

            };

            _context.Features.Add(feature);
            await _context.SaveChangesAsync();

            return feature.FeatureId;
        }

        public async Task UpdateFeatureAsync(int featureId, FeatureModel featureModel)
        {
            var feature = await _context.Features.FindAsync(featureId);

            if (feature != null)
            {
                feature.Code = featureModel.Code;
                feature.Name = featureModel.Name;
                feature.Description = featureModel.Description;

                await _context.SaveChangesAsync();
            }





        }


        public async Task DeleteFeatureAsync(int featureId)
        {

            var feature = new Features() { FeatureId = featureId };

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();


        }
    }
    
}
