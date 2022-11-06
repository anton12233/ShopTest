
using ShopTest.Data.Interfaces;
using ShopTest.Data.Models;
using System.Collections.Generic;

namespace ShopTest.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {

        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }


        public IEnumerable<Category> AllCategories => appDBContent.Categories;
    }
}
