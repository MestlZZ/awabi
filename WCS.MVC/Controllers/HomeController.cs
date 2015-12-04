using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Databases;
using WCS.Models;
using WCS.Business;

namespace WCS.MVC
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUsPage()
        {
            NotesBusiness.AddUniversityToDb();
            return View();
        }
        public ActionResult SearchPage()
        {
            return View();
        }
    }
}