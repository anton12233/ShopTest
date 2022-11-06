using ShopTest.Data.Models;
using System.Collections.Generic;

namespace ShopTest.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
