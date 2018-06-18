using MVCChurchDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCChurchDirectory.Controllers
{
    public class HomeController : Controller
    {
        static string connString = "Data Source=(LocalDB)\\v12.0; " +
            "Integrated Security=SSPI;" +
            "AttachDbFileName=|DataDirectory|\\ChurchDir.MDF;";
        private ChurchDBContext dtb = new ChurchDBContext(connString);

        public ActionResult Index()
        {
            return View();
        }

       
    }
}