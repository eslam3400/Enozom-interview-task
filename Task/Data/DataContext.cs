using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeds.Hotels(modelBuilder);
            Seeds.HotelPrices(modelBuilder);
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelPrices> HotelPrices { get; set; }

        internal object Entry(Hotel entity)
        {
            throw new NotImplementedException();
        }
    }
}
