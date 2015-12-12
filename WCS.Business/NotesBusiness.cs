using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Text.RegularExpressions;
using WCS.Models;
using WCS.Databases;
using WCS.Business;


namespace WCS.Business
{
    public static class NotesBusiness
    {
        public static IList<Note> GetList()
        {
            Notes db = new Notes();
            return db.GetList();
        }

        public static void Add(Note note)
        {
            if (note != null)
            {
                Notes db = new Notes();
                db.Save( note );
            }
        }

        public static Note Get(string id)
        {
            Notes db = new Notes();
            return db.Get(id);
        }

        public static void Delete(string id)
        {
            Notes db = new Notes();
            db.Delete(id);
        }

        public static IList<Note> GetListFromUniversity(string univerId)
        {
            Notes db = new Notes();
            var notes = db.GetList();
            System.Collections.Generic.List<Note> uNotes = new System.Collections.Generic.List<Note>();
            foreach (var note in notes)
            {
                if (note.UniversityID == univerId)
                {
                    uNotes.Add(note);
                }
            }
            return uNotes;
        }

        public static IList<Note> GetListFromState(string stateId)
        {
            Notes db = new Notes();
            var notes = db.GetList();
            System.Collections.Generic.List<Note> uNotes = new System.Collections.Generic.List<Note>();
            University univer;
            foreach (var note in notes)
            {
                univer = UniversityBusiness.Get(note.UniversityID);
                if (univer.StateID == stateId)
                {
                    uNotes.Add(note);
                }
            }
            return uNotes;
        }


    }
}