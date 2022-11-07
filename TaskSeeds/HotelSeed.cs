using Microsoft.EntityFrameworkCore;
using TaskModels;

namespace TaskSeeds
{
    public static class HotelSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Hotel 1" },
                new Hotel { Id = 2, Name = "Hotel 2" },
                new Hotel { Id = 3, Name = "Hotel 3" },
                new Hotel { Id = 4, Name = "Hotel 4" }
            );
        }
    }
}
