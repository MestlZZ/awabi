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
        [HttpGet]
        public ActionResult ComputePage( string UniversityID = null, int radio = 0, bool chose = false )
        {
            University univer = new University();
            if (radio == 0 || UniversityID == null)
            {
                univer = null;
                return View( univer );
            }
            else
            {
                univer = UniversityBusiness.GetUniversity( UniversityID );
                ViewBag.sum =  NotesBusiness.GetAverageNoteForUniversity( UniversityID, chose, radio );
                return View( univer );
            }
        }
        public ActionResult Univers()
        {
            string selectedGenreId = this.ControllerContext.ParentActionViewContext.ViewData.Model as string;

            var univers = UniversityBusiness.GetUniversityList();

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
