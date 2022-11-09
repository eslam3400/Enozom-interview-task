using Microsoft.AspNetCore.Mvc;
using TaskModels.DTO.HotelPrices;
using TaskServices.Interfacs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult Post(int id, [FromBody] List<HotelPricesDTO> prices)
        {
            hotelPricesService.AddNewHotelPrices(id, prices);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HotelPricesDTO price)
        {
            hotelPricesService.UpdateHotelPrice(id, price);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            hotelPricesService.DeleteHotelPrice(id);
            return Ok();
        }
    }
}
