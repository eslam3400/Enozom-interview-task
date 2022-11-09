using TaskModels.DTO.HotelPrices;
using TaskRepositories.Interfaces;
using TaskServices.Interfacs;

namespace TaskServices
{
    public class HotelPricesService : IHotelPricesService
    {
        private readonly IHotelPricesRepository _repository;
        public HotelPricesService(IHotelPricesRepository repository) { _repository = repository; }
        public void AddNewHotelPrice(HotelPricesDTO hotelPrice)
        {
            _repository.Add(hotelPrice);
        }

        public void AddNewHotelPrices(int id, List<HotelPricesDTO> hotelPrices)
        {
            _repository.AddMany(id, hotelPrices);
        }

        public List<HotelPricesDTO> AllPrices(int id)
        {
            return _repository.GetAll(id);
        }

        public void DeleteHotelPrice(int id)
        {
            _repository.Delete(id);
        }

        public void UpdateHotelPrice(int id, HotelPricesDTO hotelPrices)
        {
            _repository.Update(id,hotelPrices);
        }
    }
}
