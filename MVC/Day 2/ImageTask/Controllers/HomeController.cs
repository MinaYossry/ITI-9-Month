using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowDetails(string Id, string Name, string Image)
        {
            ViewBag.Id = Id;
            ViewBag.Name = Name;
            ViewBag.Image = Image;
            return View();
        }

    }
}