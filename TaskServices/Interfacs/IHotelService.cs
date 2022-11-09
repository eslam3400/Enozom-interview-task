using TaskModels;
using TaskModels.DTO.Hotel;

namespace TaskServices.Interfacs
{
    public interface IHotelService
    {
        List<SearchResult> SearchByDate(DateTime dateTime, DateTime endTime);
        List<HotelDTO> AllHotels();
        HotelDTO GetHotelById(int id);
        void AddNewHotel(HotelDTO hotel);
        void UpdateHotel(int id, HotelDTO hotel);
        void DeleteHotel(int id);
    }
}
