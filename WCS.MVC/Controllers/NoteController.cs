using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Models;
using WCS.Business;
using System.Net.Mail;
using System.Net;
using System.Text;
using WCS.Databases;

namespace WCS.MVC.Controllers
{
    public class NoteController : Controller
    {
        [HttpGet]
        public ActionResult StudentPage( string UniversityID = null, int choose = 0, bool contract = false)
        {
            ViewBag.Title = "Відправка форми";
            UniversityInfo univ = new UniversityInfo();
            univ.IsContract = contract;
            univ.Choose = choose;
            univ.UniversityID = UniversityID;
            if (choose != 0)
                ViewBag.Model2 = univ;
            else
                ViewBag.Model2 = null;
            return View();
        }

        [HttpPost]
        public ActionResult StudentPage(Note note)
        {
            ViewBag.Title = "Відправка форми";
            note.MinimalTaitionFee = note.MaximalTaitionFee;
            if(note.ExpensesTravel != 0 && note.ExpensesFood !=0)
                if (ModelState.IsValid)
                {
                    if(NotesBusiness.IsInBase( note ) == false)
                        NotesBusiness.Add(note);
                    return RedirectToAction( "Success", new { Id = note.UniversityID } );
                }
            return View();
        }

        public ActionResult Success( string Id )
        {
            ViewBag.Title = "Успішно";
            var model = UniversityBusiness.Get( Id );
            return View( model );
        }

        public ActionResult MailSuccess( string Id )
        {
            ViewBag.Title = "Відправлено";
            var body = new StringBuilder();
            body.AppendFormat( "Посмотри пожалуйста университет с id: {0}", Id );
            Feedback feedback = new Feedback();
            feedback.Mail = "admin@awabi.com";
            feedback.Name = "Admin";
            feedback.Text = body.ToString();
            Feedbacks db = new Feedbacks();
            feedback.Id = db.GetLastId() + 1;
            db.Add( feedback );
            return View();
        }

        public void SendMail( string smtpServer, string from, string password, string mailto, string caption, string message, string attachFile = null )
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress( from );
                mail.To.Add( new MailAddress( mailto ) );
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty( attachFile ))
                    mail.Attachments.Add( new Attachment( attachFile ) );
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential( from.Split( '@' )[0], password );
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Send( mail );
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception( "Mail.Send: " + e.Message );
            }
        }

        public ActionResult ListPage( int page = 1 )
        {
            ViewBag.Title = "Список університетів";

            if (page < 1)
                page = 1;

            var unInformations = UniversityBusiness.GetListFiveUniversityInfo( page - 1 );

            if (unInformations == null)
                page--;

            if (page < 1)
                return View();

            unInformations = UniversityBusiness.GetListFiveUniversityInfo( page - 1 );

            ViewBag.Page = page;

            return View(unInformations);
        }

        public ActionResult DetailedPage( string id  = null )
        {
            ViewBag.Title = "Детальна інформація";
            return View( UniversityBusiness.GetInfo( id ) );
        }

        public ActionResult UpdateInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateInfo( Note note )
        {
            if (note.ExpensesTravel != 0 && note.ExpensesFood != 0)
                if (ModelState.IsValid)
                {
                    NotesBusiness.Add( note );
                }
            return View();
        }

        [HttpGet]
        public ActionResult ComputePage( string UniversityID = null, int choose = 0, bool contract = false, bool award = false )
        {
            ViewBag.Title = "Розрахунок для абітурієнта";
            if (choose == 0 || UniversityBusiness.Get(UniversityID) == null)
            {
                return View();
            }
            else
            {
                UniversityInfo univer;
                univer = UniversityBusiness.GetInfo(UniversityID, contract, award, choose);
                return View(univer);
            }
        }

        public ActionResult Univers()
        {
            string selectedGenreId = this.ControllerContext.ParentActionViewContext.ViewData.Model as string;

            var univers = UniversityBusiness.GetList();

            var model = new SelectList(univers, "UniversityId", "Name", selectedGenreId);

            this.ViewData.Model = model;
            this.ViewData.ModelMetadata = this.ControllerContext.ParentActionViewContext.ViewData.ModelMetadata;

            return View("DropDown");
        }

        public ActionResult DeleteNote(string id)
        {
            NotesBusiness.Delete(id);
            return RedirectToRoute("List");
        }
    }
}
