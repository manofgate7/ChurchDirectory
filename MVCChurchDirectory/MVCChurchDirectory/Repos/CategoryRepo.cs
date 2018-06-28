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
            try
            {
                dtb.Categories.Add(category);
                dtb.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            categories = dtb.Categories.ToList();
            return categories;
        }

        public Category GetCategory(int CatID)
        {
            Category category = dtb.Categories.Single(m => m.CatID == CatID);
            return category;
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                Category uCategory = dtb.Categories.Single(m => m.CatID == category.CatID);
                uCategory.Name = category.Name;
                dtb.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public int? FindCategory(string name)
        {
            try
            {
                Category category = dtb.Categories.Single(m => m.Name.Equals( name));
                if(category != null)
                {
                    return category.CatID;
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }
    }
}