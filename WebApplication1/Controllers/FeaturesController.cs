using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureRepository _featureRepository;

        public FeaturesController(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }




        [HttpGet("")]
        public async Task<IActionResult> GetAllFeatures()
        {
            var features = await _featureRepository.GetAllFeaturesAsync();
            return Ok(features);

        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById([FromRoute] int id)
        {
            var feature = await _featureRepository.GetFeatureByIdAsync(id);
            if (feature == null)
            {
                return NotFound();
            }


            return Ok(feature);

        }



        [HttpPost("")]
        public async Task<IActionResult> AddNewFeature([FromBody] FeatureModel featureModel)
        {
            var id = await _featureRepository.AddFeatureAsync(featureModel);
            return CreatedAtAction(nameof(GetFeatureById), new { id = id, controller = "features" }, id);

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeature([FromBody] FeatureModel featureModel, [FromRoute] int id)
        {
            await _featureRepository.UpdateFeatureAsync(id, featureModel);
            return Ok();

        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature([FromRoute] int id)
        {
            await _featureRepository.DeleteFeatureAsync(id);
            return Ok();

        }
    }
}
