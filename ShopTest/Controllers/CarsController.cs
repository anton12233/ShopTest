using Microsoft.AspNetCore.Mvc;
using ShopTest.ViewModels;
using ShopTest.Data.Interfaces;
using System.Collections.Generic;
using ShopTest.Data.Models;
using System.Linq;

namespace ShopTest.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategory;

        public CarsController(IAllCars allCars, ICarsCategory allCategory)
        {
            _allCars = allCars;
            _allCategory = allCategory;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";

            if (string.IsNullOrEmpty(_category))
            {
                cars = _allCars.getAllCars.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("electro", _category, System.StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.getAllCars.Where(i => i.Category.CategoryName.Equals("Электро")).OrderBy(i => i.id);
                    currCategory = "Электромобили";
                }
                else if (string.Equals("fuel", _category, System.StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.getAllCars.Where(i => i.Category.CategoryName.Equals("ДВС")).OrderBy(i => i.id);
                    currCategory = "Классические автомобили";
                }
            }


            var carObj = new CarListViewModel
            {
                getAllCars = cars,
                currCategory = currCategory
            };
            ViewBag.Title = "Страница с автомобилями";

            return View(carObj);
        }
    }
}
