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
        private IPerson personRepo = new PersonRepo();
        
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
                List<Person> people = personRepo.GetPeople();
                foreach (var person in people)
                {
                    EditPersonViewModel personVM = EditPersonViewModel.Map(person);
                    if (person.CategoryID > 0)
                        personVM.Category = catRepo.GetCategory(person.CategoryID).Name;
                    editPersonViewModel.Add(personVM);
                }
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
        public ActionResult NewViewPerson()
        {
            return PartialView("_AddPerson");
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

        [HttpPost]
        public ActionResult CreatePerson(Person form)
        {

            bool hasSaved = personRepo.AddNewPerson(form);
            if (hasSaved)
                return RedirectToAction("Index");
            else
                return PartialView("_AddPerson");
        }
    }
}