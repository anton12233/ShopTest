using Microsoft.AspNetCore.Mvc;
using ShopTest.Data.Interfaces;
using ShopTest.ViewModels;

namespace ShopTest.Controllers
{
    public class UserController:Controller
    {
        public IAllUser allUser;

        public UserController(IAllUser allUser)
        {
            this.allUser = allUser;
        }

        public ViewResult Index()
        {
            var user = new UserViewModel
            {
                //favCars = _carRep.getFavCars
            };

            return View(user);
        }


    }
}
