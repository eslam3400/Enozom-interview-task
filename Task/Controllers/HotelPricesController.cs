using Microsoft.AspNetCore.Mvc;
using TaskContext;
using TaskModels;
using TaskRepositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelPricesController : ControllerBase
    {
        private readonly DataContext context;
        public HotelPricesController(DataContext context){ this.context = context; }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAll(int id)
        {
            var repo = new HotelPricesRepository(context);
            var prices = repo.GetAll(id);
            if (prices.Count <= 0) return NotFound("No Data");
            return Ok(prices);
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult Post(int id, [FromBody] List<HotelPrices> prices)
        {
            var repo = new HotelPricesRepository(context);
            repo.AddMany(id, prices);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HotelPrices price)
        {
            var repo = new HotelPricesRepository(context);
            repo.Update(id, price);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var repo = new HotelPricesRepository(context);
            repo.Delete(id);
            return Ok();
        }
    }
}
