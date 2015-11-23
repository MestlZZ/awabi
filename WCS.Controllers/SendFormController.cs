using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Models;
using WCS.Databases;

namespace WCS.Controllers
{
    public class SendFormController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Відправка форми";
            return View();
        }
        [HttpPost]
        public ActionResult Index(Note note)
        {
            /*if (ModelState.IsValid)
            {
                SetChangesInDb db = new SetChangesInDb();
                db.SaveDb( note );
                return RedirectToRoute( new { controller = "Home", action = "Index" } );
            }*/
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