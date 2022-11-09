using TaskRepositories;
using TaskModels;

namespace TaskServices
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository hotelRepository;
        private readonly IHotelPricesRepository hotelPricesRepository;
        public HotelService(IHotelRepository hotelRepository, IHotelPricesRepository hotelPricesRepository)
        {
            this.hotelRepository = hotelRepository;
            this.hotelPricesRepository = hotelPricesRepository;
        }

        public void AddNewHotel(Hotel hotel)
        {
            hotelRepository.Add(hotel);
            if(hotel.Prices.Count > 0) hotelPricesRepository.AddMany(hotel.Id,hotel.Prices);
            hotelRepository.Save();
            hotelPricesRepository.Save();
        }

        public List<Hotel> AllHotels()
        {
            return hotelRepository.GetAll();
        }

        public void DeleteHotel(int id)
        {
            hotelRepository.Delete(id);
        }

        public Hotel GetHotelById(int id)
        {
            return hotelRepository.Get(id);
        }

        public List<SearchResult> SearchByDate(DateTime startDate, DateTime endDate)
        {
            var hotels = hotelRepository.SearchByDate(startDate, endDate);
            int daysCount = (endDate - startDate).Days + 1;
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

        public void UpdateHotel(int id, Hotel hotel)
        {
            hotelRepository.Update(id, hotel);
        }
    }
    public class SearchResult
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public float TotalPrice { get; set; }
    }
}
