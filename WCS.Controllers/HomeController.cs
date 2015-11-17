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
        public ActionResult Index()
        {
            return RedirectToRoute( new { controller = "SendForm", action = "Index" } );
            /*ViewBag.Title = "Домашня сторінка";
            GetNoteFromDb db = new GetNoteFromDb();
            SendForm sf = new SendForm();
            sf = db.GetNote( id );
            if (sf == null)
                return HttpNotFound();
            ViewBag.ID = id;
            return View(sf);*/
        }
    }
}