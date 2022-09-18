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
    public class PropertyInfosController : ControllerBase
    {
        private readonly IPropertyInfoRepository _propertyInfoRepository;

        public PropertyInfosController(IPropertyInfoRepository propertyInfoRepository)
        {
            _propertyInfoRepository = propertyInfoRepository;
        }




        [HttpGet("")]
        public async Task<IActionResult> GetAllPropertyInfos()
        {
            var propertyInfos = await _propertyInfoRepository.GetAllPropertyInfosAsync();
            return Ok(propertyInfos);

        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyInfoById([FromRoute] int id)
        {
            var propertyInfo = await _propertyInfoRepository.GetPropertyInfoByIdAsync(id);
            if (propertyInfo == null)
            {
                return NotFound();
            }


            return Ok(propertyInfo);

        }



        [HttpPost("")]
        public async Task<IActionResult> AddNewPropertyInfo([FromBody] PropertyInfoModel propertyInfoModel)
        {
            var id = await _propertyInfoRepository.AddPropertyInfoAsync(propertyInfoModel);
            return CreatedAtAction(nameof(GetPropertyInfoById), new { id = id, controller = "propertyInfos" }, id);

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePropertyInfo([FromBody] PropertyInfoModel propertyInfoModel, [FromRoute] int id)
        {
            await _propertyInfoRepository.UpdatePropertyInfoAsync(id, propertyInfoModel);
            return Ok();

        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyInfo([FromRoute] int id)
        {
            await _propertyInfoRepository.DeletePropertyInfoAsync(id);
            return Ok();

        }
    }
}

