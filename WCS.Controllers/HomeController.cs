using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Databases;
using WCS.Models;

namespace WCS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AbiturientForm()
        {
            ViewBag.Title = "Відправка форми";
            return View();
        }
        [HttpPost]
        public ActionResult AbiturientForm( Note note )
        {
            if (ModelState.IsValid)
            {
                SetChangesInDb db = new SetChangesInDb();
                db.Save( note );
                return Index();
            }
            ViewBag.Title = "Відправка форми [ПОМИЛКА!]";
            return View();
        }
        public ActionResult StudentForm()
        {
            ViewBag.Title = "Форма студента";
            GetNoteFromDb db = new GetNoteFromDb();
            ViewBag.List = db.GetUniversityis();
            return View();
        }
    }
}