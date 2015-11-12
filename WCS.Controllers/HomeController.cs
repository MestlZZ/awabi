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
        public ActionResult Index( int id = 1 )
        {
            if (id < 1)
                return HttpNotFound();
            ViewBag.Title = "Домашня сторінка";
            GetDb db = new GetDb();
            SendForm sf = new SendForm();
            sf = db.GetForm( id );
            if (sf == null)
                return HttpNotFound();
            ViewBag.ID = id;
            return View(sf);
        }
    }
}