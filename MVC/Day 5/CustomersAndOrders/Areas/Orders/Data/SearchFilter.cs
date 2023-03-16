using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CustomersAndOrders.Areas.Orders.Data
{ 
    class SearchFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "ErrorPage",
                ViewBag = { ExceptionMessage = exception.Message }
            };


            base.OnException(filterContext);
        }
    }
}