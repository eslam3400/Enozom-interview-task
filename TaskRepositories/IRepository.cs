using TaskModels;
using TaskModels.DTO.Hotel;

namespace TaskRepositories
{
    public interface IRepository<Model>
    {
        List<Model> GetAll();
        Model Get(int id);
        void Add(Model entity);
        void Update(int id, Model entity);
        void Delete(int id);
        void Save();
    }

    public interface IHotelRepository : IRepository<Hotel>
    {
        List<HotelSearch> SearchByDate(DateTime startDate, DateTime endDate);
    }

    public interface IHotelPricesRepository : IRepository<HotelPrices>
    {
        void AddMany(int id, List<HotelPrices> hotelPrices);
        List<HotelPrices> GetAll(int id);

    }
}
