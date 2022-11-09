using TaskContext;
using TaskModels;
using TaskModels.DTO.HotelPrices;
using TaskRepositories.Interfaces;

namespace TaskRepositories
{
    public class HotelPricesRepository : IHotelPricesRepository
    {
        private readonly DataContext context;
        public HotelPricesRepository(DataContext context) { this.context = context; }
        public void Add(HotelPricesDTO entity)
        {
            var price = new HotelPrices { Id = entity.Id, Date = entity.Date, Price = entity.Price, HotelId = entity.HotelId };
            context.HotelPrices.Add(price);
            Save();
        }

        public void AddMany(int id, List<HotelPricesDTO> prices)
        {
            foreach (HotelPricesDTO item in prices)
            {
                var price = new HotelPrices { HotelId = item.HotelId, Price = item.Price, Date = item.Date };
                context.HotelPrices.Add(price);
            }
        }

        public void Delete(int id)
        {
            var price = Get(id);
            context.HotelPrices.Remove(new HotelPrices { Id = price.Id, Date = price.Date, Price = price.Price, HotelId = price.HotelId });
            Save();
        }

        public HotelPricesDTO Get(int id)
        {
            var price = context.HotelPrices.Find(id);
            return new HotelPricesDTO { Id = price.Id, Date = price.Date, Price = price.Price, HotelId = price.HotelId };
        }

        public List<HotelPricesDTO> GetAll(int hotelId)
        {
            var prices = context.HotelPrices.Where(filter => filter.HotelId == hotelId).ToList();
            var pricesDto = new List<HotelPricesDTO>();
            foreach (var price in pricesDto)
                pricesDto.Add(new HotelPricesDTO { Date = price.Date, HotelId = price.HotelId, Price = price.Price, Id = price.Id});
            return pricesDto;
        }

        public List<HotelPricesDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, HotelPricesDTO entity)
        {
            var hotel = Get(id);
            hotel.Date = entity.Date;
            hotel.Price = entity.Price;
            Save();
        }
    }
}
