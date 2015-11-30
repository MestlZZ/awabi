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
        public ActionResult Index(string Id)
        {
            Notes db = new Notes();
            Note note = db.Get( Id );
            string[] index = db.GetListId();

            if (note == null)
            {
                if (index.Length > 1)
                    Id = index[1];
                else
                    return RedirectToRoute( "AbiturientForm" );

                note = db.Get( Id );
            }

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
        public ActionResult Index( string id, int del )
        {
            del = Convert.ToInt32( id ) - 1;
            Notes db = new Notes();
            db.Delete( id.ToString() );
            return RedirectToAction( "Index", "Home", new { Id = del.ToString() } );
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
            ViewBag.List = db.GetList();
            return View();
        }

        public ActionResult Univers()
        {
            string selectedGenreId = this.ControllerContext.ParentActionViewContext.ViewData.Model as string;
            Universiteties db = new Universiteties();

            var univers = db.GetList();

            var model = new SelectList(univers, "UniversityId", "Name", selectedGenreId);

            this.ViewData.Model = model;
            this.ViewData.ModelMetadata = this.ControllerContext.ParentActionViewContext.ViewData.ModelMetadata;

            return View( "DropDown" );
        }
    }
}