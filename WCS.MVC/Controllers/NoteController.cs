using System;
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
        public ActionResult AbiturientPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AbiturientPage( Note note )
        {
            if(ModelState.IsValid)
            {
                NotesBusiness.Add( note );
            }
            return View();
        }
        public ActionResult StudentPage()
        {
            return View();
        }
        public ActionResult ListPage()
        {
            var model = NotesBusiness.GetList();
            return View( model );
        }
        public ActionResult DetailedPage( string id )
        {
            return View( NotesBusiness.GetNote( id ));
        }
        public ActionResult ComputePage()
        {
            return View();
        }
        public ActionResult Univers()
        {
            string selectedGenreId = this.ControllerContext.ParentActionViewContext.ViewData.Model as string;

            var univers = NotesBusiness.GetUniversityList();

            var model = new SelectList(univers, "UniversityId", "Name", selectedGenreId);

            this.ViewData.Model = model;
            this.ViewData.ModelMetadata = this.ControllerContext.ParentActionViewContext.ViewData.ModelMetadata;

            return View( "DropDown" );
        }
        public ActionResult DeleteNote( string id )
        {
            NotesBusiness.DelteNote( id );
            return RedirectToRoute( "List" );
        }
    }
}
