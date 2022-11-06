using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ShopTest.Data;
using ShopTest.Data.Interfaces;
using ShopTest.Data.Models;
using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;

namespace ShopTest.Controllers
{
    public class LoginController : Controller
    {

        private IAllLogin _loginRep;
        private Auth _auth;
        private UserShop user;

        public LoginController(IAllLogin loginRep, Auth auth)
        {
            _loginRep = loginRep;
            _auth = auth;
        }

        public IActionResult Logining()
        {

            if (User.Identity.Name == null)
                return View();
            
            return Logout();
        }


        [HttpPost]
        public IActionResult Logining(Login login)
        {
            user = _auth.setAuth(login);

            if (user is null)
            {
                ModelState.AddModelError("CustomError", "Пользователь не найден");
                return View();
            }
            else
            {
                Authenticate(login.loginName);
                return RedirectToAction("Complete");
            }

        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Авторизация успешна";
            return View();
        }

        private void Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }



    }
}
