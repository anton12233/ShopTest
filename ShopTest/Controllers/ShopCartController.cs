using Microsoft.AspNetCore.Mvc;
using ShopTest.Data.Interfaces;
using ShopTest.Data.Models;
using ShopTest.Data.Repository;
using ShopTest.ViewModels;
using System.Linq;

namespace ShopTest.Controllers
{
    public class ShopCartController : Controller
    {
        private IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }


        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItims = items;


            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.getAllCars.FirstOrDefault(i => i.id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }

    }
}
