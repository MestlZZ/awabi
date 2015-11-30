using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Databases;
using WCS.Models;

namespace WCS.MVC
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int Id = 1)
        {
            string id = Id.ToString();
            Notes db = new Notes();
            Note note = db.GetNote( id );
            if (note == null)
                return RedirectToRoute("AbiturientForm");
            int[] index = db.GetNotesId();
            int ind = Array.IndexOf(index, Id);
            if (ind + 1 < index.Length)
            {
                ViewBag.NextInd = index[ind + 1];
                ViewBag.Next = true;
            }
            else
                ViewBag.Next = false;
            if (ind - 1 != 0)
            {
                ViewBag.Past = true;
                ViewBag.PastInd = index[ind - 1];
            }
            else
                ViewBag.Past = false;
            return View( note );
        }

        [HttpPost]
        public ActionResult Index( long id )
        {
            Notes db = new Notes();
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
                Notes db = new Notes();
                db.Save( note );
                return RedirectToAction( "Index", "Home", new { Id = Convert.ToInt32( note.Id ) } );
            }
            ViewBag.Title = "Відправка форми [ПОМИЛКА!]";
            return View();
        }

        public ActionResult StudentForm()
        {
            ViewBag.Title = "Форма студента";
            Universiteties db = new Universiteties();
            ViewBag.List = db.GetUniversityis();
            return View();
        }
    }
}