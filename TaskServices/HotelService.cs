using TaskServices.Interfacs;
using TaskModels.DTO.Hotel;
using TaskRepositories.Interfaces;

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

        public void AddNewHotel(HotelDTO hotel)
        {
            hotelRepository.Add(hotel);
            if(hotel.Prices.Count > 0) hotelPricesRepository.AddMany(hotel.Id,hotel.Prices);
            hotelRepository.Save();
        }

        public List<HotelDTO> AllHotels()
        {
            return hotelRepository.GetAll();
        }

        public void DeleteHotel(int id)
        {
            hotelRepository.Delete(id);
        }

        public HotelDTO GetHotelById(int id)
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

        public void UpdateHotel(int id, HotelDTO hotel)
        {
            hotelRepository.Update(id, hotel);
        }
    }
}
