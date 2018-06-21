using MVCChurchDirectory.Models;
using MVCChurchDirectory.Repos;
using MVCChurchDirectory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCChurchDirectory.Controllers
{
    public class AdminController : Controller
    {
        private ICategory catRepo = new CategoryRepo();
        
        public ActionResult Index()
        {
            AdminViewModel adminVM = new AdminViewModel();
            List<AdminDropListModel> model = new List<AdminDropListModel>();
            model.Add(new AdminDropListModel { ID = 0, Name = "People" });
            model.Add(new AdminDropListModel { ID = 1, Name = "Church Jobs" });
            adminVM.AdminList = model;
            return View(adminVM);
        }

        [HttpGet]
        public ActionResult GrabAdminPage(int categoryId)
        {
            if(categoryId == 0){
                List<EditPersonViewModel> editPersonViewModel = new List<EditPersonViewModel>();
                return PartialView("_AdminPersonMain", editPersonViewModel);
            }
            else if(categoryId == 1)
            {
                List<Category> categories = new List<Category>();
                categories = catRepo.GetCategories();
                return PartialView("_AdminCategoryMain", categories);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult NewViewCat()
        {
            return PartialView("_AddCategory");
        }

        [HttpGet]
        public ActionResult EditViewCat(int CatID)
        {
            Category category = catRepo.GetCategory(CatID);
            return PartialView("_EditCategory", category);
        }

        [HttpPost]
        public ActionResult CreateCategory(FormCollection form)
        {
            Category category = new Category() { Name = form["name"] };
            bool hasSaved = catRepo.AddNewCategory(category);
            if(hasSaved)
                return RedirectToAction("Index");
            else 
                return PartialView("_AddCategory");
        }

        [HttpPost]
        public ActionResult EditCategory(Category cat)
        {
            bool hasSaved = catRepo.UpdateCategory(cat);
            if (hasSaved)
                return RedirectToAction("Index");
            else
                return PartialView("_EditCategory");
        }
    }
}