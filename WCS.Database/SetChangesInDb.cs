using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Text.RegularExpressions;
using WCS.Models;
using WCS.Databases;

namespace WCS.Databases
{
    public class SetChangesInDb
    {
        NoteContext db = new NoteContext();
        public void Save(Note note)
        {
            db.Notes.Add(note);
            db.SaveChanges();
        }
        public void Save(State state)
        {
            db.States.Add(state);
            db.SaveChanges();
        }
        public void Update(Note note)
        {
            db.Entry(note).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Update( State state )
        {
            db.Entry( state ).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Update( University univers )
        {
            db.Entry( univers ).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(Note note)
        {
            db.Notes.Remove( note );
            db.SaveChanges();
        }
    }
}
