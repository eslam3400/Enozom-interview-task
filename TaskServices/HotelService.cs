using TaskRepositories;
using TaskModels;

namespace TaskServices
{
    public class HotelService
    {
        private readonly HotelRepository hotelRepo;
        public HotelService(IRepository<Hotel> hotelRepo) { this.hotelRepo = (HotelRepository?)hotelRepo; }
        public List<SearchResult> SearchByDate(DateTime startDate, DateTime endDate)
        {
            int daysCount = (endDate - startDate).Days + 1;
            var hotels = hotelRepo.SearchByDate(startDate, endDate);
            var finalResult = new List<SearchResult>();
            for (int i = 0; i < hotels.Count; i++)
            {
                var hotel = hotels[i];
                if (hotels.Count(filter => filter.HotelId == hotel.HotelId) < daysCount) continue;
                if (finalResult.Count(filter => filter.HotelId == hotel.HotelId) <= 0)
                {
                    finalResult.Add(new SearchResult { HotelId = hotel.HotelId, HotelName = hotel.Name, TotalPrice = hotel.Price });
                    continue;
                }
                var index = finalResult.FindIndex(filter => filter.HotelId == hotel.HotelId);
                finalResult[index].TotalPrice += hotel.Price;
            }
            return finalResult;
        }
    }
    public class SearchResult
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public float TotalPrice { get; set; }
    }
}
