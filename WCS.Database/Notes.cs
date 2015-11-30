using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Databases
{
    public class Notes
    {
        NoteContext db = new NoteContext();
        public Note GetNote( string Id )
        {
            if (Id == null)
            {
                return null;
            }
            Note note = db.Notes.Find(Id);
            if (note == null)
            {
                return null;
            }
            return note;
        }
        public IList<Note> GetNotes()
        {
            return db.Notes.ToList();
        }
        public int[] GetNotesId()
        {
            IList<Note> notes = db.Notes.ToList();
            int[] indexs = new int[db.Notes.Count() + 1];
            Array.Clear( indexs, 0, db.Notes.Count() );
            int i = 1;
            foreach(Note not in notes)
            {
                indexs[i] = Convert.ToInt32( not.Id );
                i++;
            }
            return indexs;
        }
        public void Save( Note note )
        {
            if (note != null)
            {
                note.Id = GetLastID();
                db.Notes.Add( note );
            }
            db.SaveChanges();
        }
        private string GetLastID()
        {
            Note note;
            int id = 0;
            do
            {
                id++;
                note = db.Notes.Find( id.ToString() );
            } while (note != null);
            return id.ToString();
        }
        public void Delete( string Id )
        {
            Note note = db.Notes.Find( Id );
            if (note != null)
            {
                db.Notes.Remove( note );
                db.SaveChanges();
            }
        }
        public void Update( Note note )
        {
            db.Entry( note ).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
