using ShopTest.Data.Models;
using System.Collections.Generic;

namespace ShopTest.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> getAllCars { get; }
        IEnumerable<Car> getFavCars { get; }
        Car getCarById(int carId);

    }
}
