using ShopTest.Data.Interfaces;
using ShopTest.Data.Models;
using System;

namespace ShopTest.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDBContent content;
        private readonly ShopCart shopCart;

        public OrderRepository(AppDBContent content, ShopCart shopCart)
        {
            this.content = content;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            content.Order.Add(order);

            var items = shopCart.listShopItims;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    carID = el.car.id,
                    orderID = order.id,
                    price = el.car.price

                };
                content.OrderDetail.Add(orderDetail);
            }
            content.SaveChanges();
        }
    }
}
