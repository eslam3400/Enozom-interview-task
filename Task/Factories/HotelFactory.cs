using Task.Factories.Hotels;
using Task.Models;

namespace Task.Factories
{
    public class HotelFactory
    {
        public const int HOTEL_1 = 1;
        public const int HOTEL_2 = 2;
        public const int HOTEL_3 = 3;
        public const int HOTEL_4 = 4;
        public static Hotel CreateHotel(int id)
        {
            switch (id)
            {
                case HOTEL_1:
                    return new Hotel1();
                case HOTEL_2:
                    return new Hotel2();
                case HOTEL_3:
                    return new Hotel3();
                case HOTEL_4:
                    return new Hotel4();
                default:
                    return new Hotel();
            }
        }
    }
}
