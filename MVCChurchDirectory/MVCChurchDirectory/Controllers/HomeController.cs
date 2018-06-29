using MVCChurchDirectory.Models;
using MVCChurchDirectory.Repos;
using MVCChurchDirectory.ViewModels;
using MvcPaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCChurchDirectory.Controllers
{
    public class HomeController : Controller
    {
        private IPerson personRepo = new PersonRepo();
        private IKid kidRepo = new PersonRepo();
        private ICategory categoryRepo = new CategoryRepo();
        private static int DefaultPageSize = 5;

        public ActionResult Index(string search, string searchBy, int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            List<HomePersonViewModel> personViewModel = new List<HomePersonViewModel>();
            List<Person> people; 
            if (search != null && searchBy == "Job")
            {
                int? id = categoryRepo.FindCategory(search);
                if(id != null)
                {
                    people = personRepo.GetSearchedPeople(id ?? 0);
                }
                else
                {
                    people = new List<Person>();
                }
            } else if(search != null)
            {
                people = personRepo.GetSearchedPeople(search);
            }
            else
            {
                people = personRepo.GetPeople();
            }
            foreach (var person in people)
            {
                HomePersonViewModel personVM = HomePersonViewModel.Map(person);
                if(person.CategoryID > 0)
                    personVM.Category = categoryRepo.GetCategory(person.CategoryID).Name;

                personVM.MatarialStatus = CreateMartailList(person.MatStatus);
                personViewModel.Add(personVM);
            }
            return View(personViewModel.ToPagedList(currentPageIndex, DefaultPageSize));
        }

        public ActionResult GetPerson(int id)
        {
            var person = personRepo.GetPerson(id);
            HomePersonViewModel personVM = HomePersonViewModel.Map(person);
            if (person.CategoryID > 0)
                personVM.Category = categoryRepo.GetCategory(person.CategoryID).Name;
            personVM.Children = kidRepo.GetChildren(person.ID);
            var mPerson = personRepo.GetPerson(person.PersonMarriedTo ?? -1);
            if(mPerson != null)
                personVM.MarriedTo = mPerson.FirstName + " " + mPerson.LastName;
            personVM.MatarialStatus = CreateMartailList(person.MatStatus);
            return PartialView("_PersonDetails", personVM);
        }

        [NonAction]
        public string CreateMartailList(int? status)
        {
            List<MaritalVModel> list = new List<MaritalVModel>
            {
                new MaritalVModel(0, "Single"),
                new MaritalVModel(1, "Married"),
                new MaritalVModel(2, "Divorced"),
                new MaritalVModel(3, "Widowed")
            };

            if(status != null)
            {
                return list.FirstOrDefault(x => x.ID == status).Name;
            }else
            {
                return String.Empty;
            }
            
        }



    }
}