using Microsoft.EntityFrameworkCore;

namespace TaskModels.Seeds
{
    public static class HotelSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Hotel h1 = HotelFactory.CreateHotel(1);
            //Hotel h2 = HotelFactory.CreateHotel(2);
            //Hotel h3 = HotelFactory.CreateHotel(3);
            //Hotel h4 = HotelFactory.CreateHotel(4);
            //modelBuilder.Entity<Hotel>().HasData(h1, h2, h3, h4);
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Hotel 1" },
                new Hotel { Id = 2, Name = "Hotel 2" },
                new Hotel { Id = 3, Name = "Hotel 3" },
                new Hotel { Id = 4, Name = "Hotel 4" }
            );
        }
    }
}
