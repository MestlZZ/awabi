﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Models;
using WCS.Business;

namespace WCS.MVC.Controllers
{
    public class NoteController : Controller
    {
        [HttpGet]
        public ActionResult StudentPage( string UniversityID = null, int radio = 0, bool chose = false )
        {
            ViewBag.Title = "Відправка форми";
            UniversityInfo univ = new UniversityInfo();
            univ.Contract = chose;
            univ.Choose = radio;
            univ.UniversityID = UniversityID;
            if (radio != 0)
                ViewBag.Model2 = univ;
            else
                ViewBag.Model2 = null;
            return View();
        }

        [HttpPost]
        public ActionResult StudentPage(Note note)
        {
            ViewBag.Title = "Відправка форми";
            if(note.ExpensesTravel != 0 && note.ExpensesFood !=0)
                if (ModelState.IsValid)
                {
                    NotesBusiness.Add(note);
                    return RedirectToAction( "Success", new { Id = note.UniversityID } );
                }
            return View();
        }

        public ActionResult Success( string Id )
        {
            var model = UniversityBusiness.Get( Id );
            return View( model );
        }

        public ActionResult ListPage()
        {
            ViewBag.Title = "Список записів";
            var model = UniversityBusiness.GetListUniversityInfo();
            return View(model);
        }

        public ActionResult DetailedPage( string id  = null )
        {
            ViewBag.Title = "Детальна інформація";
            return View( UniversityBusiness.GetInfo( id ) );
        }

        public ActionResult UpdateInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateInfo( Note note )
        {
            if (note.ExpensesTravel != 0 && note.ExpensesFood != 0)
                if (ModelState.IsValid)
                {
                    NotesBusiness.Add( note );
                }
            return View();
        }

        [HttpGet]
        public ActionResult ComputePage(string UniversityID = null, int radio = 0, bool chose = false)
        {
            ViewBag.Title = "Розрахунок для абітурієнта";
            if (radio == 0 || UniversityBusiness.Get(UniversityID) == null)
            {
                return View();
            }
            else
            {
                UniversityInfo univer;
                univer = UniversityBusiness.GetInfo(UniversityID, chose, radio);
                return View(univer);
            }
        }

        public ActionResult Univers()
        {
            string selectedGenreId = this.ControllerContext.ParentActionViewContext.ViewData.Model as string;

            var univers = UniversityBusiness.GetList();

            var model = new SelectList(univers, "UniversityId", "Name", selectedGenreId);

            this.ViewData.Model = model;
            this.ViewData.ModelMetadata = this.ControllerContext.ParentActionViewContext.ViewData.ModelMetadata;

            return View("DropDown");
        }

        public ActionResult DeleteNote(string id)
        {
            NotesBusiness.DeleteNote(id);
            return RedirectToRoute("List");
        }
    }
}
