using Microsoft.EntityFrameworkCore;
using TaskModels;

namespace TaskSeeds
{
    public static class HotelPricesSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
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
