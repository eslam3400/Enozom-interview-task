using TaskModels.DTOs.HotelPrices;

namespace TaskRepositories.Interfaces
{
    public interface IHotelPricesRepository : IRepository<HotelPricesDTO>
    {
        void AddMany(int id, List<HotelPricesDTO> hotelPrices);
        List<HotelPricesDTO> GetAll(int id);

    }
}
