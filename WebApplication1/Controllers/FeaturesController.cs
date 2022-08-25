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




        [HttpGet("{code}")]
        public async Task<IActionResult> GetFeatureByCode([FromRoute] string code)
        {
            var feature = await _featureRepository.GetFeatureByCodeAsync(code);
            if (feature == null)
            {
                return NotFound();
            }


            return Ok(feature);

        }



        [HttpPost("")]
        public async Task<IActionResult> AddNewFeature([FromBody] FeatureModel featureModel)
        {
            var code = await _featureRepository.AddFeatureAsync(featureModel);
            return CreatedAtAction(nameof(GetFeatureByCode), new { code = code, controller = "features" }, code);

        }



        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateFeature([FromBody] FeatureModel featureModel, [FromRoute] string code)
        {
            await _featureRepository.UpdateFeatureAsync(code, featureModel);
            return Ok();

        }




        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteFeature([FromRoute] string code)
        {
            await _featureRepository.DeleteFeatureAsync(code);
            return Ok();

        }
    }
}
