using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Models;
using WCS.Database;

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
                SetChangesInDb db = new SetChangesInDb();
                db.SaveInDb( send );
                return RedirectToAction( "Index" );
            }
            return RedirectToRoute( new { controller = "Home", action = "Index" } );
        }
    }
}