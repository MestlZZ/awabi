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
        public ActionResult Index()
        {
            ViewBag.Title = "Відправка форми";
            return View();
        }
    }
}