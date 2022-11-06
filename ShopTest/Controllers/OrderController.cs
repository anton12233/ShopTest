using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShopTest.Data;
using ShopTest.Data.Interfaces;
using ShopTest.Data.Models;

namespace ShopTest.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        private readonly Auth _auth;

        public OrderController(IAllOrders allOrders, ShopCart shopCart, Auth auth)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
            this._auth = auth;
        }


        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listShopItims = shopCart.getShopItems();

            if(shopCart.listShopItims.Count == 0)
            {
                ModelState.AddModelError("","У вас должны быть товары!");
            }
            
            if (ModelState.IsValid)
            {
                var ord = order;
                ord.userID = _auth.getIDbyLogin(User.Identity.Name);
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }

    }
}
