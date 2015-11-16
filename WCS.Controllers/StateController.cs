﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Models;
using WCS.Databases;

namespace WCS.Controllers
{
    public class StateController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Запис областей";

            return View();
        }
        [HttpPost]
        public ActionResult Index(State send)
        {
            ///проверка на валидность данных что были переданы моделе
            if (ModelState.IsValid)
            {
                SetChangesInDb db = new SetChangesInDb();
                db.SaveInDb(send);
                return RedirectToAction("Index");
            }
            return RedirectToRoute(new { controller = "State", action = "Index" });
        }
    }
}