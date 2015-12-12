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

        public University Get( string Id )
        {
            if (Id == null)
            {
                return null;
            }
            University university = db.Universities.Find(Id);
            return university;
        }

        public IList<University> GetList()
        {
            return db.Universities.ToList();
        }

        public void AddList( IList<University> univers )
        {
            db.Universities.AddRange( univers );
            db.SaveChanges();
        }

        public void Update( University univers )
        {
            if (univers == null)
                return;
            db.Entry( univers ).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
