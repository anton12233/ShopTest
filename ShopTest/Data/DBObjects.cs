using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShopTest.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopTest.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {





            if (!content.Categories.Any())
            {
                content.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Cars.Any())
            {
                content.AddRange(
                    new Car { name = "Tesla", shortDesc = "", longDesc = "", img = "/img/tesla.jpg", price = 45000, isFavourite = true, available = true, Category = Categories["Электро"] },
                    new Car { name = "Nissan", shortDesc = "", longDesc = "", img = "/img/Nissan.jpg", price = 15000, isFavourite = true, available = true, Category = Categories["ДВС"] },
                    new Car { name = "BMW", shortDesc = "", longDesc = "", img = "/img/BMW.jpg", price = 55000, isFavourite = true, available = true, Category = Categories["ДВС"] },
                    new Car { name = "Lada", shortDesc = "", longDesc = "", img = "/img/Lada.jpg", price = 60000, isFavourite = true, available = true, Category = Categories["ДВС"] }
                    );

            }


            content.SaveChanges();
        }



        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                {
                    new Category { CategoryName = "Электро", Desc = "Почти тесла" },
                    new Category { CategoryName = "ДВС", Desc = "Совсем не тесла" }
                };
                    category = new Dictionary<string, Category>();

                    foreach (Category categ in list)
                    {
                        category.Add(categ.CategoryName, categ);
                    }
                }
                return category;
            }
        }
    }
}
