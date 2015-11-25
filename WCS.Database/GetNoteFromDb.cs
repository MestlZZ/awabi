using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Databases
{
    public class GetNoteFromDb
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
        public State GetState( string Id )
        {
            if (Id == null)
            {
                return null;
            }
            State state = db.States.Find(Id);
            if (state == null)
            {
                return null;
            }
            return state;
        }
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
        public IList<State> GetStates()
        {
            return db.States.ToList();
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
        public IList<University> GetUniversityis()
        {
            return db.Universities.ToList();
        }
    }
}
