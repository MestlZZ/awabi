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
        NoteContext db = new NoteContext();
        public void SaveDb(Note note)
        {
            db.Notes.Add(note);
            db.SaveChanges();
        }
        public void SaveDb(State state)
        {
            db.States.Add(state);
            db.SaveChanges();
        }
        public void UpdateDb(Note note)
        {
            db.Entry(note).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void UpdateDb( State state )
        {
            db.Entry( state ).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteDb(Note note)
        {
            db.Notes.Remove( note );
            db.SaveChanges();
        }
        public void DeleteDb( State state )
        {
            db.States.Remove( state );
            db.SaveChanges();
        }
        public void DeleteDb()
        {
            db.Database.Delete();
            db.SaveChanges();
        }
    }
}
