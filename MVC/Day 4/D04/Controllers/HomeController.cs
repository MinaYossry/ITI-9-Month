using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace D04.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Code500()
        {
            return RedirectToAction("Error/500");
        }

        public ActionResult Error(int Id) 
        {
            ViewBag.ErrorCode = Id;
            if (Id == 404)
                ViewBag.ErrorMessage = "Page coudn't be found";
            else if (Id == 500)
                ViewBag.ErrorMessage = "Internal Server Error";

            return View();
        }
    }
}