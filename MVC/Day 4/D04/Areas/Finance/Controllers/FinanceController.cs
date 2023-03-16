using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace D04.Areas.Finance.Controllers
{
    [HandleError(View = "ErrorPage")]
    public class FinanceController : Controller
    {
        // GET: Finance/Finance
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            throw new DivideByZeroException();
        }
    }
}