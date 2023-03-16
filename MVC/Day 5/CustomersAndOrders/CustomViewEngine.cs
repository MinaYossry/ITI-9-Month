using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomersAndOrders
{
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            // Define the search locations for views
            AreaViewLocationFormats = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };

            AreaPartialViewLocationFormats = AreaViewLocationFormats;
            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.vbhtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.vbhtml"
            };
            PartialViewLocationFormats = ViewLocationFormats;
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            // Use the correct area and controller names in the view path
            var areaName = controllerContext.RouteData.DataTokens["area"] as string;
            var controllerName = controllerContext.RouteData.Values["controller"] as string;
            var partialViewPath = string.Format($"~/Areas/{areaName}/Views/{controllerName}/{partialPath}");

            return base.CreatePartialView(controllerContext, partialViewPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            // Use the correct area and controller names in the view path
            var areaName = controllerContext.RouteData.DataTokens["area"] as string;
            var controllerName = controllerContext.RouteData.Values["controller"] as string;
            var fullViewPath = string.Format($"~/Areas/{areaName}/Views/{controllerName}/{viewPath}");

            return base.CreateView(controllerContext, fullViewPath, masterPath);
        }
    }

}