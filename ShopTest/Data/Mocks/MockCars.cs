using ShopTest.Data.Interfaces;
using ShopTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopTest.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _carsCategory = new MockCategory();

        public IEnumerable<Car> getAllCars
        {
            get
            {
                return new List<Car>
                {
                    new Car {name = "Tesla", shortDesc = "", longDesc = "", img = "/img/tesla.jpg", price = 45000, isFavourite = true, available = true, Category = _carsCategory.AllCategories.First()},
                    new Car {name = "Nissan", shortDesc = "", longDesc = "", img = "/img/Nissan.jpg", price = 45000, isFavourite = true, available = true, Category = _carsCategory.AllCategories.First()},
                    new Car {name = "BMW", shortDesc = "", longDesc = "", img = "/img/BMW.jpg", price = 45000, isFavourite = true, available = true, Category = _carsCategory.AllCategories.First()},
                    new Car {name = "Lada", shortDesc = "", longDesc = "", img = "/img/Lada.jpg", price = 45000, isFavourite = true, available = true, Category = _carsCategory.AllCategories.Last()}
                };
            }
        }
            



        public IEnumerable<Car> getFavCars { get; set;}

        public Car getCarById(int carId)
        {
 
            throw new Exception();
        }
    }
}
