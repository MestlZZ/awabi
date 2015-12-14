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
        public Note Get( string Id )
        {
            if (Id == null)
            {
                return null;
            }
            Note note = db.Notes.Find(Id);
            return note;
        }
        public IList<Note> GetList()
        {
            return db.Notes.ToList();
        }
        public string[] GetListId()
        {
            IList<Note> notes = db.Notes.ToList();
            string[] indexs = new string[db.Notes.Count() + 1];
            Array.Clear( indexs, 0, db.Notes.Count() );
            int i = 1;
            foreach(Note not in notes)
            {
                indexs[i] =  not.Id;
                i++;
            }
            return indexs;
        }

        public Note IsInBase( Note note )
        {
            return db.Notes.Find( note );
        }

        public void Save( Note note )
        {
            if (note == null)
                return;
                note.Id = GetLastId();
                db.Notes.Add( note );
                db.SaveChanges();
        }
        private string GetLastId()
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
            if (note == null)
                return;
            db.Notes.Remove( note );
            db.SaveChanges();
        }
        public void Update( Note note )
        {
            if (note == null)
                return;
            db.Entry( note ).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void WorkWithNote()
        {
            var notes = GetList();
            foreach (var note in notes)
            {
                db.Notes.Remove( note );
                note.MaximalTaitionFee /= 12.0;
                note.MinimalTaitionFee /= 12.0;
                db.Notes.Add( note );                
            }
        }
    }
}
