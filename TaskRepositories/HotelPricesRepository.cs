using TaskContext;
using TaskModels;

namespace TaskRepositories
{
    public class HotelPricesRepository : IHotelPricesRepository
    {
        private readonly DataContext context;
        public HotelPricesRepository(DataContext context) { this.context = context; }
        public void Add(HotelPrices entity)
        {
            context.HotelPrices.Add(entity);
            Save();
        }

        public void AddMany(int id, List<HotelPrices> prices)
        {
            foreach (HotelPrices item in prices)
            {
                item.HotelId = id;
                context.HotelPrices.Add(item);
            }
        }

        public void Delete(int id)
        {
            context.HotelPrices.Remove(Get(id));
            Save();
        }

        public HotelPrices Get(int id)
        {
            return context.HotelPrices.Find(id);
        }

        public List<HotelPrices> GetAll(int hotelId)
        {
            return context.HotelPrices.Where(filter => filter.HotelId == hotelId).ToList();
        }

        public List<HotelPrices> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, HotelPrices entity)
        {
            var hotel = Get(id);
            hotel.Date = entity.Date;
            hotel.Price = entity.Price;
            Save();
        }
    }
}
