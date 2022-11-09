using TaskModels;

namespace TaskRepositories.Interfaces
{
    public interface IHotelPricesRepository : IRepository<HotelPrices>
    {
        void AddMany(int id, List<HotelPrices> hotelPrices);
        List<HotelPrices> GetAll(int id);

    }
}
