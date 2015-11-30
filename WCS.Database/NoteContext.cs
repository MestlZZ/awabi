using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Databases
{
    public class NoteContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<State> States { get; set; }
    }
}
