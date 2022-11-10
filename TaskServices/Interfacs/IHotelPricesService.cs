using TaskModels;
using TaskModels.DTOs.HotelPrices;

namespace TaskServices.Interfacs
{
    public interface IHotelPricesService
    {
        List<HotelPricesDTO> AllPrices(int id);
        void AddNewHotelPrice(HotelPricesDTO hotelPrices);
        void AddNewHotelPrices(int id, List<HotelPricesDTO> hotelPrices);
        void UpdateHotelPrice(int id, HotelPricesDTO hotelPrices);
        void DeleteHotelPrice(int id);
    }
}
