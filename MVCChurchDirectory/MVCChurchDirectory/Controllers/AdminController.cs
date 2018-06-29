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
        private IKid kidRepo = new PersonRepo();


        public ActionResult Index(int? lID)
        {
            AdminViewModel adminVM = new AdminViewModel();
            List<AdminDropListModel> model = new List<AdminDropListModel>();
            model.Add(new AdminDropListModel { ID = 1, Name = "People" });
            model.Add(new AdminDropListModel { ID = 2, Name = "Church Jobs" });
            adminVM.AdminList = model;
            if(lID != null)
            {
                adminVM.SelectedID = lID ?? 0;
            }
            return View(adminVM);
        }

        [HttpGet]
        public ActionResult GrabAdminPage(int categoryId)
        {
            if(categoryId == 1){
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
            else if(categoryId == 2)
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
            EditPersonViewModel pVModel = new EditPersonViewModel();
            pVModel.Categories = catRepo.GetCategories();
            var people = personRepo.GetPeople();
            List<PersonNameViewModel> peopleList = new List<PersonNameViewModel>();
            foreach(var person in people)
            {
                PersonNameViewModel personVM = PersonNameViewModel.Map(person);
                peopleList.Add(personVM);
            }
            pVModel.people = peopleList;
            pVModel.MartialStatuses = CreateMartailList();
            pVModel.YNOptions = CreateOptions();
            return PartialView("_AddPerson", pVModel);
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
            if (hasSaved)
            {
                return RedirectToAction("Index", new {lID = 2 });
            }
                
            else 
                return PartialView("_AddCategory");
        }

        [HttpPost]
        public ActionResult EditCategory(Category cat)
        {
            bool hasSaved = catRepo.UpdateCategory(cat);
            if (hasSaved)
                return RedirectToAction("Index", new { lID = 2 });
            else
                return PartialView("_EditCategory");
        }

        [HttpPost]
        public ActionResult CreatePerson(EditPersonViewModel form)
        {
            Person person = Person.Map(form);
            bool hasSaved = personRepo.AddNewPerson(person);
            if (hasSaved)
            {
                
                return RedirectToAction("Index", new { lID = 1 });
            } 
            else
                return PartialView("_AddPerson");
        }

        [HttpGet]
        public ActionResult EditViewPerson(int personID)
        {
            Person person = personRepo.GetPerson(personID);
            EditPersonViewModel pViewModel = EditPersonViewModel.Map(person);
            pViewModel.Categories = catRepo.GetCategories();
            var people = personRepo.GetPeople();
            List<PersonNameViewModel> peopleList = new List<PersonNameViewModel>();
            people.Remove(people.FirstOrDefault(x => x.ID == personID));
            foreach (var personL in people)
            {
                PersonNameViewModel personVM = PersonNameViewModel.Map(personL);
                peopleList.Add(personVM);
            }
            pViewModel.people = peopleList;
            pViewModel.MartialStatuses = CreateMartailList();
            pViewModel.YNOptions = CreateOptions();
            pViewModel.Children = kidRepo.GetChildren(person.ID);
            return PartialView("_EditPerson", pViewModel);
        }

        [HttpPost]
        public ActionResult EditPerson(EditPersonViewModel form)
        {
            Person person = Person.Map(form);
            bool hasSaved = personRepo.UpdatePerson(person);
            if (hasSaved)
                return RedirectToAction("Index", new { lID = 1 });
            else
                return PartialView("_EditPerson");
        }

        [NonAction]
        public List<MaritalVModel> CreateMartailList()
        {
            List<MaritalVModel> list = new List<MaritalVModel>
            {
                new MaritalVModel(0, "Single"),
                new MaritalVModel(1, "Married"),
                new MaritalVModel(2, "Divorced"),
                new MaritalVModel(3, "Widowed")
            };
            return list;
        }

        [NonAction]
        public Dictionary<bool, string> CreateOptions()
        {
            Dictionary<bool, string> options = new Dictionary<bool, string>();
            options.Add(false, "no");
            options.Add(true, "yes");

            return options;
        }

        [HttpGet]
        public ActionResult ModalPopUpKid(int personID)
        {
            Child child = new Child();
            child.PersonID = personID;
            return PartialView("_ModalPopUpKid", child);
        }

        [HttpGet]
        public ActionResult EditModalKid(int ChildID)
        {
            Child child = kidRepo.GetChild(ChildID);
            
            return PartialView("_EditModalKid", child);
        }

        [HttpPost]
        public ActionResult CreateChild(Child child)
        {
            bool hasSaved = kidRepo.AddNewChild(child);
            if (hasSaved)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { error = "Error! Can't Save Data!" });
            }
            
        }

        [HttpPost]
        public ActionResult EditChild(Child child)
        {
            bool hasSaved = kidRepo.UpdateChild(child);
            if (hasSaved)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { error = "Error! Can't Save Data!" });
            }

        }
        
    }
}