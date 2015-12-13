using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Databases;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WCS.Models;
using WCS.Business;

namespace WCS.MVC
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Головна сторінка";
            return View();
        }

        public ActionResult AboutUsPage()
        {
            ViewBag.Title = "Про нас";
            return View();
        }

        public ActionResult SearchPage()
        {
            ViewBag.Title = "Пошук";
            return View();
        }

        public ActionResult FeedbackPage()
        {
            ViewBag.Title = "Залишити відгук";
            return View();
        }
        [HttpPost]
        public ActionResult FeedbackPage( Feedback feedback )
        {
            ViewBag.Title = "Залишити відгук";
            if(ModelState.IsValid)
            {
                Feedbacks db = new Feedbacks();
                feedback.Id = db.GetLastId() + 1;
                db.Add( feedback );
            }
            return RedirectToAction("Index");
        }
    }
}