using Microsoft.AspNetCore.Mvc;
using Task.Repositories;
using Task.Services;
using TaskModels;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelRepository hotelRepo;
        private readonly HotelService hotelService;
        public HotelController(IRepository<Hotel> repo)
        {
            this.hotelRepo = (HotelRepository?)repo;
            this.hotelService = new HotelService(this.hotelRepo);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] SearchQueryParams query)
        {
            DateTime startDate = new DateTime(2000, 1, 1);
            DateTime endDate = new DateTime(3000, 1, 1);
            //validation that start and end dates are provided & in a correct format from query
            if (!DateTime.TryParse(query.Start, out startDate) || !DateTime.TryParse(query.End, out endDate))
                return BadRequest("Please make sure input is valid date");
            var hotels = hotelService.SearchByDate(startDate, endDate);
            if (hotels.Count <= 0) return NotFound("No Data");
            return Ok(hotels);
        }
    }

    public class SearchQueryParams
    {
        public string Start { get; set; }
        public string End { get; set; }
    }
}
