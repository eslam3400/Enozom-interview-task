using Microsoft.EntityFrameworkCore;
using Task.Factories;
using Task.Models;

namespace Task.Data
{
    public static class Seeds
    {
        public static void Hotels(this ModelBuilder modelBuilder)
        {
            Hotel h1 = HotelFactory.CreateHotel(1);
            Hotel h2 = HotelFactory.CreateHotel(2);
            Hotel h3 = HotelFactory.CreateHotel(3);
            Hotel h4 = HotelFactory.CreateHotel(4);
            //modelBuilder.Entity<Hotel>().HasData(h1, h2, h3, h4);
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Hotel 1" },
                new Hotel { Id = 2, Name = "Hotel 2" },
                new Hotel { Id = 3, Name = "Hotel 3" },
                new Hotel { Id = 4, Name = "Hotel 4" }
            );
        }

        public static void HotelPrices(this ModelBuilder modelBuilder)
        {
            int idCounter = 1;
            modelBuilder.Entity<HotelPrices>().HasData(
                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 1), Price = 50, HotelId = 1 },
                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 2), Price = 50, HotelId = 1 },
                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 4), Price = 60, HotelId = 1 },
                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 5), Price = 65, HotelId = 1 },

                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 1), Price = 20, HotelId = 2 },
                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 2), Price = 25, HotelId = 2 },
                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 3), Price = 20, HotelId = 2 },
                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 4), Price = 21, HotelId = 2 },
                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 5), Price = 23, HotelId = 2 },

                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 1), Price = 21, HotelId = 3 },
                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 4), Price = 20, HotelId = 3 },
                new HotelPrices { Id = idCounter++, Date = new DateTime(2024, 1, 5), Price = 25, HotelId = 3 }
            );
        }
    }
}
