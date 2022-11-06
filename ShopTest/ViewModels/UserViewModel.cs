using ShopTest.Data.Models;
using System.Collections.Generic;

namespace ShopTest.ViewModels
{
    public class UserViewModel
    {
        public UserShop user;
        public IEnumerable<Order> list;

    }
}
