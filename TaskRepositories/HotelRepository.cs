using Microsoft.EntityFrameworkCore;
using TaskModels;
using TaskModels.DTO;
using TaskContext;

namespace TaskRepositories
{
    public class HotelRepository : IRepository<Hotel>
    {
        private readonly DataContext context;

        public HotelRepository(DataContext context) { this.context = context; }
        public void Add(Hotel entity)
        {
            context.Hotels.Add(entity);
            Save();
        }
        public void Delete(int id)
        {
            context.Hotels.Remove(context.Hotels.Find(id));
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
            context.Entry(entity).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public List<HotelSearchDTO> SearchByDate(DateTime startDate, DateTime endDate)
        {
            return context.Hotels.Join(
                    context.HotelPrices,
                    hotel => hotel.Id,
                    prices => prices.HotelId,
                    (hotel, prices) => new HotelSearchDTO { HotelId = hotel.Id, Name = hotel.Name, Date = prices.Date, Price = prices.Price }
                ).Where(hotel => startDate <= hotel.Date && hotel.Date <= endDate).ToList();
        }
    }
}
