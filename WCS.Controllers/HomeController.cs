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
        [HttpGet]
        public ActionResult Index(int Id = 1)
        {
            string id = Id.ToString();
            GetNoteFromDb db = new GetNoteFromDb();
            ViewBag.Id = Id;
            Note note = db.GetNote( id );
            if (note == null)
                return RedirectToRoute("AbiturientForm");
            if (db.GetNote( (Id + 1).ToString() ) != null)
                ViewBag.Next = true;
            else
                ViewBag.Next = false;
            if (db.GetNote( (Id - 1).ToString() ) != null)
                ViewBag.Past = true;
            else
                ViewBag.Past = false;
            return View( note );
        }
        [HttpPost]
        public ActionResult Index( long id )
        {
            SetChangesInDb db = new SetChangesInDb();
            db.Delete( id.ToString() );
            return RedirectToAction( "Index", "Home", new { Id = (id-1) } );
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
                return RedirectToAction( "Index", "Home", new { Id = Convert.ToInt32( note.Id ) } );
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