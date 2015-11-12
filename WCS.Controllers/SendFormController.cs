using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Models;

namespace WCS.Controllers
{
    public class SendFormController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ///Титулка =)
            ViewBag.Title = "Відправка форми";
            return View();
        }
        [HttpPost]
        public ActionResult Index(SendForm send)
        {
            ///проверка на валидность данных что были переданы моделе
            if (ModelState.IsValid)
            {
                return RedirectToAction( "Index" );
            }
            return RedirectToRoute( new { controller = "Home", action = "Index" } );
        }
    }
}