using MVCChurchDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCChurchDirectory.Repos
{
   public interface ICategory
    {
        List<Category> GetCategories();
        Category GetCategory(int CatID);
        bool UpdateCategory(Category category);
        bool AddNewCategory(Category category);
        int? FindCategory(string name);
    }
}
