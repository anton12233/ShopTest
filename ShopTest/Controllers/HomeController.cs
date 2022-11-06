using Microsoft.AspNetCore.Mvc;
using ShopTest.Data.Interfaces;
using ShopTest.Data.Models;
using ShopTest.ViewModels;

namespace ShopTest.Controllers
{
    public class HomeController : Controller
    {
        private IAllCars _carRep;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }


        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favCars = _carRep.getFavCars
            };

            return View(homeCars);
        }
    }
}
