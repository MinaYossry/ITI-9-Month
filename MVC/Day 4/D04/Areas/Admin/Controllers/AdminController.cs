﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace D04.Areas.Admin.Controllers
{
    [HandleError(View = "ErrorPage")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            throw new ArgumentException();
        }
    }
}