using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCS.MVC
{
    public class ErrorController : Controller
    {
        public ActionResult PageNotFound()
        {
            ViewBag.Title = "Помилка 404";
            Response.StatusCode = 404;
            return View();
        }
    }
}