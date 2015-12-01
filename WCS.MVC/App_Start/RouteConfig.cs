﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WCS.MVC;

namespace WCS.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Abiturient",
                url: "abiturient",
                defaults: new { controller = "Note", action = "AbiturientPage" }
            );

            routes.MapRoute(
                name: "Student",
                url: "student",
                defaults: new { controller = "Note", action = "StudentPage" }
            );

            routes.MapRoute(
               name: "About",
               url: "about",
               defaults: new { controller = "Home", action = "AboutUsPage"}
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
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
