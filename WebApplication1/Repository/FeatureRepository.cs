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
        private readonly FeatureContext _context;

        public FeatureRepository(FeatureContext context)
        {
            _context = context;
        }

        public async Task<List<FeatureModel>> GetAllFeaturesAsync()
        {
            var records = await _context.Features.Select(x => new FeatureModel()
            {
                Code = x.Code,
                Name = x.Name,
                Description = x.Description
                

            }).ToListAsync();

            return records;
        }

        public async Task<FeatureModel> GetFeatureByCodeAsync(string featureCode)
        {
            var records = await _context.Features.Where(x => x.Code == featureCode).Select(x => new FeatureModel()
            {

                Code = x.Code,
                Name = x.Name,
                Description = x.Description

            }).FirstOrDefaultAsync();

            return records;
        }

        public async Task<string> AddFeatureAsync(FeatureModel featuretModel)
        {

            var feature = new Features()
            {
                
                Code = featuretModel.Code,
                Name = featuretModel.Name,
                Description = featuretModel.Description

            };

            _context.Features.Add(feature);
            await _context.SaveChangesAsync();

            return feature.Code;
        }

        public async Task UpdateFeatureAsync(string featureCode, FeatureModel featureModel)
        {
            var feature = await _context.Features.FindAsync(featureCode);

            if (feature != null)
            {
               
                feature.Name = featureModel.Name;
                feature.Description = featureModel.Description;

                await _context.SaveChangesAsync();
            }





        }


        public async Task DeleteFeatureAsync(string featureCode)
        {

            var feature = new Features() { Code = featureCode };

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();


        }
    }
    
}
