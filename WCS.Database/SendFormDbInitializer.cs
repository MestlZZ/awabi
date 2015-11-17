using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Databases
{
    public class SendFormDbInitializer : DropCreateDatabaseIfModelChanges<SendFormContext>
    {
        protected override void Seed( SendFormContext db )
        {
            base.Seed( db );
        }
    }
}
