using Microsoft.EntityFrameworkCore;
using ShopTest.Data.Models;

namespace ShopTest.Data
{
    public class AppDBContent : DbContext
    {

        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<UserShop> Users { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
