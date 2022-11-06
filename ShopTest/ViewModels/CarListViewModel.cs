using ShopTest.Data.Models;
using System.Collections.Generic;

namespace ShopTest.ViewModels
{
    public class CarListViewModel
    {
        public IEnumerable<Car> getAllCars { get; set; }

        public string currCategory { get; set; }

    }
}
