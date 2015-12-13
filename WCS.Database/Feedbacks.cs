using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS.Models;

namespace WCS.Databases
{
    public class Feedbacks
    {
        NoteContext db = new NoteContext();
        public void Add( Feedback feedback )
        {
            if(feedback != null)
            {
                db.Feedbacks.Add( feedback );
                db.SaveChanges();
            }
        }
        public void Delete( int id )
        {
            db.Feedbacks.Remove( db.Feedbacks.Find( id ) );
            db.SaveChanges();
        }
        public int GetLastId()
        {
            return db.Feedbacks.Count();
        }
    }
}
