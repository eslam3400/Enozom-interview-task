using Microsoft.EntityFrameworkCore;
using TaskModels;
using TaskContext;
using TaskModels.DTO.Hotel;

namespace TaskRepositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DataContext context;

        public HotelRepository(DataContext context) { this.context = context; }
        public void Add(Hotel entity)
        {
            context.Hotels.Add(entity);
        }
        public void Delete(int id)
        {
            context.Hotels.Remove(Get(id));
            Save();
        }
        public Hotel Get(int id)
        {
            return context.Hotels.Find(id);
        }
        public List<Hotel> GetAll()
        {
            return context.Hotels.ToList();
        }
        public void Update(int id, Hotel entity)
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
