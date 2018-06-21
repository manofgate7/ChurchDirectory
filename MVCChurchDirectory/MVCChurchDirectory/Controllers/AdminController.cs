using MVCChurchDirectory.Models;
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
                return PartialView("_AdminCategoryMain", categories);
            }

            return RedirectToAction("Index");
        }
    }
}