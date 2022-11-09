using TaskModels;

namespace TaskServices.Interfacs
{
    public interface IHotelPricesService
    {
        List<HotelPrices> AllPrices(int id);
        void AddNewHotelPrice(HotelPrices hotelPrices);
        void AddNewHotelPrices(int id, List<HotelPrices> hotelPrices);
        void UpdateHotelPrice(int id, HotelPrices hotelPrices);
        void DeleteHotelPrice(int id);
    }
}
