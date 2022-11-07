using Microsoft.EntityFrameworkCore;
using TaskContext;
using TaskModels;

namespace TaskRepositories
{
    public class HotelPricesRepository : IRepository<HotelPrices>
    {
        private readonly DataContext context;
        public HotelPricesRepository(DataContext context) { this.context = context; }
        public void Add(HotelPrices entity)
        {
            context.HotelPrices.Add(entity);
        }

        public void Delete(int id)
        {
            context.HotelPrices.Remove(Get(id));
        }

        public HotelPrices Get(int id)
        {
            return context.HotelPrices.Find(id);
        }

        public List<HotelPrices> GetAll()
        {
            return context.HotelPrices.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(int id, HotelPrices entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
