using TaskContext;
using TaskModels;
using TaskModels.DTO.Hotel;
using TaskRepositories.Interfaces;

namespace TaskRepositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DataContext context;

        public HotelRepository(DataContext context) { this.context = context; }
        public void Add(HotelDTO entity)
        {
            var prices = new List<HotelPrices>();
            if (entity.Prices.Count > 0)
                foreach (var price in entity.Prices)
                    prices.Add(new HotelPrices { HotelId = entity.Id, Price = price.Price, Date = price.Date});
            var hotel = new Hotel {
                Name = entity.Name,
                Prices = prices
            };
            context.Hotels.Add(hotel);
        }
        public void Delete(int id)
        {
            var hotel = Get(id);
            context.Hotels.Remove(new Hotel { Id = hotel.Id, Name = hotel.Name });
            Save();
        }
        public HotelDTO Get(int id)
        {
            var hotel = context.Hotels.Find(id);
            return new HotelDTO { Name = hotel.Name, Id = hotel.Id };
        }
        public List<HotelDTO> GetAll()
        {
            var hotels = context.Hotels.ToList();
            var hotelsDto = new List<HotelDTO>();
            foreach (var hotel in hotels)
                hotelsDto.Add(new HotelDTO { Id = hotel.Id, Name = hotel.Name });
            return hotelsDto;
        }
        public void Update(int id, HotelDTO entity)
        {
            var hotel = Get(id);
            hotel.Name = entity.Name;
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public List<HotelSearch> SearchByDate(DateTime startDate, DateTime endDate)
        {
            return context.Hotels.Join(
                    context.HotelPrices,
                    hotel => hotel.Id,
                    prices => prices.HotelId,
                    (hotel, prices) => new HotelSearch { HotelId = hotel.Id, Name = hotel.Name, Date = prices.Date, Price = prices.Price }
                ).Where(hotel => startDate <= hotel.Date && hotel.Date <= endDate).ToList();
        }
    }
}
