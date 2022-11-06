using Microsoft.EntityFrameworkCore;
using ShopTest.Data.Interfaces;
using ShopTest.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopTest.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;

        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> getAllCars => appDBContent.Cars.Include(c => c.Category);

        public IEnumerable<Car> getFavCars => appDBContent.Cars.Where(p => p.isFavourite).Include(c => c.Category);

        public Car getCarById(int carId) => appDBContent.Cars.FirstOrDefault(p => p.id == carId);
    }
}
