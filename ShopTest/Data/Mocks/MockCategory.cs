using ShopTest.Data.Interfaces;
using ShopTest.Data.Models;
using System.Collections.Generic;

namespace ShopTest.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories 
        {
            get {
                return new List<Category> {
                    new Category { CategoryName = "Электро", Desc = "Почти тесла"},
                    new Category { CategoryName = "ДВС", Desc = "Совсем не тесла"}
                };
            }
        }
    }
}
