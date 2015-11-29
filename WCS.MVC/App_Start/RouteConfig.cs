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
                name: "AbiturientForm",
                url: "abiturient",
                defaults: new { controller = "Home", action = "AbiturientForm" }
            );

            routes.MapRoute(
                name: "StudentForm",
                url: "student",
                defaults: new { controller = "Home", action = "StudentForm" }
            );

            routes.MapRoute(
               name: "Home",
               url: "",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}