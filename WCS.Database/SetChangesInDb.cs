using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Database
{
    public class SetChangesInDb
    {
        SendFormContext db = new SendFormContext();
        public void SaveInDb(SendForm form)
        {
            db.SendForms.Add(form);
            db.SaveChanges();
        }
        public void UpdateInDb(SendForm form)
        {
            db.Entry(form).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteInDb(SendForm form)
        {
            db.SendForms.Remove( form );
            db.SaveChanges();
        }
    }
}
