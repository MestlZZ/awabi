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
        public Note GetNote( int Id )
        {
            if (Id == 0)
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
        public State GetState( int Id )
        {
            if (Id == 0)
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
        public IEnumerable<State> GetStatesFromDB()
        {
            return db.States.ToList();
        }
        public IEnumerable<Note> GetNotesFromDB()
        {
            return db.Notes.ToList();
        }
    }
}
