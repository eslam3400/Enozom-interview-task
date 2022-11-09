using TaskModels;
using TaskModels.DTO.Hotel;

namespace TaskServices.Interfacs
{
    public interface IHotelService
    {
        List<SearchResult> SearchByDate(DateTime dateTime, DateTime endTime);
        List<Hotel> AllHotels();
        Hotel GetHotelById(int id);
        void AddNewHotel(Hotel hotel);
        void UpdateHotel(int id, Hotel hotel);
        void DeleteHotel(int id);
    }
}
