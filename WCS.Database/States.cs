using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Databases
{
    public class States
    {
        NoteContext db = new NoteContext();
        public State Get( string Id )
        {
            if (Id == null)
            {
                return null;
            }
            State state = db.States.Find(Id);
            return state;
        }
        public IList<State> GetList()
        {
            return db.States.ToList();
        }
        public void Update( State state )
        {
            if (state == null)
                return;
            db.Entry( state ).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Save( State state )
        {
            if (state == null)
                return;
            db.States.Add( state );
            db.SaveChanges();
        }
    }
}
