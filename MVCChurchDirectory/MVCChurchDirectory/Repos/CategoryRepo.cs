using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCChurchDirectory.Models;

namespace MVCChurchDirectory.Repos
{
    public class CategoryRepo : ICategory
    {
        static string connString = "Data Source=(LocalDB)\\v12.0; " +
            "Integrated Security=SSPI;" +
            "AttachDbFileName=|DataDirectory|\\ChurchDir.MDF;";
        private ChurchDBContext dtb = new ChurchDBContext(connString);

        public bool AddNewCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int CatID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}