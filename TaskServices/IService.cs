using TaskModels;

namespace TaskServices
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
    public interface IHotelPricesService
    {
        List<HotelPrices> AllPrices(int id);
        void AddNewHotelPrice(HotelPrices hotelPrices);
        void AddNewHotelPrices(int id, List<HotelPrices> hotelPrices);
        void UpdateHotelPrice(int id, HotelPrices hotelPrices);
        void DeleteHotelPrice(int id);
    }
}
