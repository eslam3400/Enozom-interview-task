using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskModels.DTOs.HotelPrices;
using TaskModels.Enums;
using TaskServices.Interfacs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotelPricesController : ControllerBase
    {
        private readonly IHotelPricesService hotelPricesService;
        public HotelPricesController(IHotelPricesService hotelPricesService){ this.hotelPricesService = hotelPricesService; }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAll(int id)
        {
            var prices = hotelPricesService.AllPrices(id);
            if (prices.Count <= 0) return NotFound("No Data");
            return Ok(prices);
        }

        [HttpPost]
        [Route("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]

        public IActionResult Post(int id, [FromBody] List<HotelPricesDTO> prices)
        {
            hotelPricesService.AddNewHotelPrices(id, prices);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult Put(int id, [FromBody] HotelPricesDTO price)
        {
            hotelPricesService.UpdateHotelPrice(id, price);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult Delete(int id)
        {
            hotelPricesService.DeleteHotelPrice(id);
            return Ok();
        }
    }
}
