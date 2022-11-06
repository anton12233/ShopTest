using ShopTest.Data.Models;
using System.Collections.Generic;

namespace ShopTest.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> favCars { get; set; }
    }
}
