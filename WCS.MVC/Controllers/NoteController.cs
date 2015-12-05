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
        public ActionResult StudentPage()
        {
            ViewBag.Title = "Відправка форми";
            return View();
        }
        [HttpPost]
        public ActionResult StudentPage(Note note)
        {
            ViewBag.Title = "Відправка форми";
            if (ModelState.IsValid)
            {
                NotesBusiness.Add(note);
            }
            return View();
        }
        public ActionResult ListPage()
        {
            ViewBag.Title = "Список записів";
            var model = NotesBusiness.GetList();
            return View(model);
        }
        public ActionResult DetailedPage(string id)
        {
            ViewBag.Title = "Детальна інформація";
            return View(NotesBusiness.GetNote(id));
        }
        [HttpGet]
        public ActionResult ComputePage(string UniversityID = null, int radio = 0, bool chose = false)
        {
            ViewBag.Title = "Розрахунок для абітурієнта";
            if (radio == 0 || UniversityBusiness.GetUniversity(UniversityID) == null)
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

            var univers = UniversityBusiness.GetUniversityList();

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