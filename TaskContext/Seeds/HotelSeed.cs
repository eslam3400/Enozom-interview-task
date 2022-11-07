using Microsoft.EntityFrameworkCore;
using TaskModels;

namespace TaskContext.Seeds
{
    public static class HotelSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
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
