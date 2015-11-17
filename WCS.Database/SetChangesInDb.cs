using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Databases
{
    public class SetChangesInDb
    {
        SendFormContext db = new SendFormContext();
        public void SaveInDb(SendForm form)
        {
            db.SendForms.Add(form);
            db.SaveChanges();
        }
        public void SaveInDb(State form)
        {
            db.States.Add(form);
            db.SaveChanges();
        }
        public IEnumerable<State> GetStateFromDB()
        {
            return db.States.ToList();
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
