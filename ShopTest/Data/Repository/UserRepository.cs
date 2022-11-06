using Microsoft.EntityFrameworkCore;
using ShopTest.Data.Interfaces;
using ShopTest.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopTest.Data.Repository
{
    public class UserRepository : IAllUser
    {
        private readonly AppDBContent content;

        public UserRepository(AppDBContent appDBContent)
        {
            this.content = appDBContent;

        }



        public List<Order> GetOrders(int id)
        {
            return content.Order.Where(p => p.userID == id).ToList();
        }
    }
}
