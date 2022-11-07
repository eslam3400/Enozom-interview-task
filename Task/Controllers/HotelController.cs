using Microsoft.AspNetCore.Mvc;
using TaskRepositories;
using TaskServices;
using TaskContext;
using TaskUnitOfWork;
using TaskModels;

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
            DateTime startDate = new DateTime(2000, 1, 1);
            DateTime endDate = new DateTime(3000, 1, 1);
            //validation that start and end dates are provided & in a correct format from query
            if (!DateTime.TryParse(query.Start, out startDate) || !DateTime.TryParse(query.End, out endDate))
                return BadRequest("Please make sure input is valid date");
            var hotelRepo = new HotelRepository(context);
            var hotelService = new HotelService(hotelRepo);
            var hotels = hotelService.SearchByDate(startDate, endDate);
            if (hotels.Count <= 0) return NotFound("No Data");
            return Ok(hotels);
        }
        [HttpPost]
        public IActionResult Add([FromBody]Hotel hotel) {
            if (hotel.Name == null) { return BadRequest("Please Provide HotelName"); }
            var unitOfWork = new addHotelUnitOfWork(context);
            unitOfWork.HotelRepository.Add(hotel);
            unitOfWork.Save();
            return Ok();
        }
    }
    
    public class SearchQueryParams
    {
        public string Start { get; set; }
        public string End { get; set; }
    }
}
