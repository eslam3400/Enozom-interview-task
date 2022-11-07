using Microsoft.EntityFrameworkCore;

namespace TaskModels
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(ModelsConfig.MySqlConnectioString, ServerVersion.AutoDetect(ModelsConfig.MySqlConnectioString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seeds.HotelSeed.Seed(modelBuilder);
            Seeds.HotelPricesSeed.Seed(modelBuilder);
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelPrices> HotelPrices { get; set; }
    }
}
