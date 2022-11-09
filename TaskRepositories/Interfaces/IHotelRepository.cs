using TaskModels.DTO.Hotel;
using TaskModels;

namespace TaskRepositories.Interfaces
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        List<HotelSearch> SearchByDate(DateTime startDate, DateTime endDate);
    }
}
