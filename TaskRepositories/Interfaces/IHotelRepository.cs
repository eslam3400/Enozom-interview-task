using TaskModels.DTOs.Hotel;

namespace TaskRepositories.Interfaces
{
    public interface IHotelRepository : IRepository<HotelDTO>
    {
        List<HotelSearch> SearchByDate(DateTime startDate, DateTime endDate);
    }
}
