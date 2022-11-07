﻿using TaskRepositories;
using TaskContext;

namespace TaskUnitOfWork
{
    public class addHotelUnitOfWork
    {
        private HotelRepository hotelRepo;
        private HotelPricesRepository hotelPricesRepo;
        private DataContext context;
        public addHotelUnitOfWork(DataContext context) { this.context = context; }
        public HotelRepository HotelRepository
        {
            get
            {
                if (hotelRepo == null)
                {
                    hotelRepo = new HotelRepository(context);
                }
                return hotelRepo;
            }
        }
        public HotelPricesRepository HotelPricesRepository
        {
            get
            {
                if (hotelPricesRepo == null)
                {
                    hotelPricesRepo = new HotelPricesRepository(context);
                }
                return hotelPricesRepo;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
