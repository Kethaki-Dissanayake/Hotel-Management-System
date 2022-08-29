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
    public class PricesController : ControllerBase
    {
        private readonly IPriceRepository _priceRepository;

        public PricesController(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }




        [HttpGet("")]
        public async Task<IActionResult> GetAllPrices()
        {
            var prices = await _priceRepository.GetAllPricesAsync();
            return Ok(prices);

        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetPriceById([FromRoute] int id)
        {
            var price = await _priceRepository.GetPriceByIdAsync(id);
            if (price == null)
            {
                return NotFound();
            }


            return Ok(price);

        }



        [HttpPost("")]
        public async Task<IActionResult> AddNewPrice([FromBody] PriceModel priceModel)
        {
            var id = await _priceRepository.AddPriceAsync(priceModel);
            return CreatedAtAction(nameof(GetPriceById), new { id = id, controller = "prices" }, id);

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrice([FromBody] PriceModel priceModel, [FromRoute] int id)
        {
            await _priceRepository.UpdatePriceAsync(id, priceModel);
            return Ok();

        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> PriceFeature([FromRoute] int id)
        {
            await _priceRepository.DeletePriceAsync(id);
            return Ok();

        }
    }
}
