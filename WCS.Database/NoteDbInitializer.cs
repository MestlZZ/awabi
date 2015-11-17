using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Databases
{
    public class NoteDbInitializer : DropCreateDatabaseIfModelChanges<NoteContext>
    {
        protected override void Seed( NoteContext db )
        {
            base.Seed( db );
        }
    }
}
