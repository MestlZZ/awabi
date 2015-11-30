using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Databases
{
    public class Universiteties
    {
        NoteContext db = new NoteContext();
        public University GetUniversity( string Id )
        {
            if (Id == null)
            {
                return null;
            }
            University univers = db.Universities.Find(Id);
            if (univers == null)
            {
                return null;
            }
            return univers;
        }
        public IList<University> GetUniversityis()
        {
            return db.Universities.ToList();
        }
        public void Update( University univers )
        {
            if(univers != null)
            db.Entry( univers ).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
