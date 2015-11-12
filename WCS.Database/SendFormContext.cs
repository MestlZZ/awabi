using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Database
{
    public class SendFormContext : DbContext
    {
        public DbSet<SendForm> SendForms { get; set; }
    }
}
