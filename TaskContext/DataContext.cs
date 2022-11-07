using Microsoft.EntityFrameworkCore;
using TaskModels;
using TaskSeeds;


namespace TaskContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            HotelSeed.Seed(modelBuilder);
            HotelPricesSeed.Seed(modelBuilder);
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelPrices> HotelPrices { get; set; }
    }
}
