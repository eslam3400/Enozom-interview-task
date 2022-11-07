using Microsoft.AspNetCore.Mvc;
using TaskRepositories;
using TaskServices;
using TaskContext;
using TaskUnitOfWork;
using TaskModels;
using TaskModels.DTO.Hotel;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly DataContext context;
        public HotelController(DataContext context) { this.context = context; }

        [HttpGet]
        public IActionResult GetAll([FromQuery] SearchQueryParams query)
        {
            var hotelRepo = new HotelRepository(context);
            if(query.Start != null && query.End != null)
            {
                DateTime startDate = new DateTime(2000, 1, 1);
                DateTime endDate = new DateTime(3000, 1, 1);
                //validation that start and end dates are provided & in a correct format from query
                if (!DateTime.TryParse(query.Start, out startDate) || !DateTime.TryParse(query.End, out endDate))
                    return BadRequest("Please make sure input is valid date");
                var hotelsByDate = hotelRepo.SearchByDate(startDate, endDate);
                var hotelService = new HotelService();
                var FilterdHotels = hotelService.SearchByDate(startDate, endDate, hotelsByDate);
                if (FilterdHotels.Count <= 0) return NotFound("No Data");
                return Ok(FilterdHotels);
            }
            var hotels = hotelRepo.GetAll();
            if (hotels.Count <= 0) return NotFound("No Data");
            return Ok(hotelRepo.GetAll());
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var repo = new HotelRepository(context);
            var hotel = repo.Get(id);
            if (hotel == null) return NotFound("No Data");
            return Ok(hotel);
        }
        [HttpPost]
        public IActionResult Add([FromBody]Hotel hotel) {
            if (hotel.Name == null) { return BadRequest("Please Provide HotelName"); }
            var repo = new HotelRepository(context);
            repo.Add(hotel);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateHotel hotel)
        {
            var hotelRepo = new HotelRepository(context);
            hotelRepo.Update(id, new Hotel { Name = hotel.Name });
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var repo = new HotelRepository(context);
            repo.Delete(id);
            return Ok();
        }
    }
    
    public class SearchQueryParams
    {
        public string? Start { get; set; }
        public string? End { get; set; }
    }
}
