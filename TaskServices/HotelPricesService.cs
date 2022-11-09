using TaskModels;
using TaskRepositories;

namespace TaskServices
{
    public class HotelPricesService : IHotelPricesService
    {
        private readonly IHotelPricesRepository _repository;
        public HotelPricesService(IHotelPricesRepository repository) { _repository = repository; }
        public void AddNewHotelPrice(HotelPrices hotelPrice)
        {
            _repository.Add(hotelPrice);
        }

        public void AddNewHotelPrices(int id, List<HotelPrices> hotelPrices)
        {
            _repository.AddMany(id, hotelPrices);
        }

        public List<HotelPrices> AllPrices(int id)
        {
            return _repository.GetAll(id);
        }

        public void DeleteHotelPrice(int id)
        {
            _repository.Delete(id);
        }

        public void UpdateHotelPrice(int id, HotelPrices hotelPrices)
        {
            _repository.Update(id,hotelPrices);
        }
    }
}
