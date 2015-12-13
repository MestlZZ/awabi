using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WCS.MVC;
using WCS.Business;

namespace WCS.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Student",
                url: "student",
                defaults: new { controller = "Note", action = "StudentPage", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "About",
               url: "about",
               defaults: new { controller = "Home", action = "AboutUsPage"}
           );

            routes.MapRoute(
               name: "Success",
               url: "success",
               defaults: new { controller = "Note", action = "Success", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "List",
               url: "list",
               defaults: new { controller = "Note", action = "ListPage" }
           );

            routes.MapRoute(
               name: "Detailed",
               url: "details",
               defaults: new { controller = "Note", action = "DetailedPage", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Compute",
               url: "info",
               defaults: new { controller = "Note", action = "ComputePage", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Search",
               url: "search",
               defaults: new { controller = "Home", action = "SearchPage", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Error",
                url: "error",
                defaults: new { controller = "Error", action = "PageNotFound", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
