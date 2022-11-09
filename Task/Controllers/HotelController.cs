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
        private readonly IHotelService hotelService;
        public HotelController(IHotelService hotelService) { this.hotelService = hotelService; }

        [HttpGet]
        public IActionResult GetAll([FromQuery] SearchQueryParams query)
        {
            if(query.Start != null && query.End != null)
            {
                DateTime startDate = new DateTime(2000, 1, 1);
                DateTime endDate = new DateTime(3000, 1, 1);
                //validation that start and end dates are provided & in a correct format from query
                if (!DateTime.TryParse(query.Start, out startDate) || !DateTime.TryParse(query.End, out endDate))
                    return BadRequest("Please make sure input is valid date");
                var FilterdHotels = hotelService.SearchByDate(startDate, endDate);
                if (FilterdHotels.Count <= 0) return NotFound("No Data");
                return Ok(FilterdHotels);
            }
            var hotels = hotelService.AllHotels();
            if (hotels.Count <= 0) return NotFound("No Data");
            return Ok(hotels);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var hotel = hotelService.GetHotelById(id);
            if (hotel == null) return NotFound("No Data");
            return Ok(hotel);
        }
        [HttpPost]
        public IActionResult Add([FromBody]Hotel hotel) {
            if (hotel.Name == null) { return BadRequest("Please Provide HotelName"); }
            hotelService.AddNewHotel(hotel);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateHotel hotel)
        {
            hotelService.UpdateHotel(id, new Hotel { Name = hotel.Name });
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            hotelService.DeleteHotel(id);
            return Ok();
        }
    }
    
    public class SearchQueryParams
    {
        public string? Start { get; set; }
        public string? End { get; set; }
    }
}
