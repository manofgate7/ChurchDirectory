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
    public class HomeController : Controller
    {
        private IPerson personRepo = new PersonRepo();
        private IKid kidRepo = new PersonRepo();
        private ICategory categoryRepo = new CategoryRepo();

        public ActionResult Index(string search)
        {
            List<HomePersonViewModel> personViewModel = new List<HomePersonViewModel>();
            List<Person> people; 
            if (search != null)
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
                personVM.Category = categoryRepo.GetCategory(person.CategoryID).Name;
                personViewModel.Add(personVM);
            }

            return View(personViewModel);
        }

        public ActionResult GetPerson(int id)
        {
            var person = personRepo.GetPerson(id);
            HomePersonViewModel personVM = HomePersonViewModel.Map(person);
            personVM.Category = categoryRepo.GetCategory(person.CategoryID).Name;
            personVM.Children = kidRepo.GetChildren(person.ID);
            var mPerson = personRepo.GetPerson(person.PersonMarriedTo ?? -1);

            personVM.MarriedTo = mPerson.FirstName + " " + mPerson.LastName;
            return PartialView("_PersonDetails", personVM);
        }



    }
}