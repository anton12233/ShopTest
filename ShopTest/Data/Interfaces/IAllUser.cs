using ShopTest.Data.Models;
using System.Collections.Generic;

namespace ShopTest.Data.Interfaces
{
    public interface IAllUser
    {
        List<Order> GetOrders(int id);
    }
}
