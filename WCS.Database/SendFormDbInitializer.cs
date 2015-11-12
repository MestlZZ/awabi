using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Database
{
    public class SendFormDbInitializer : DropCreateDatabaseAlways<SendFormContext>
    {
        protected override void Seed( SendFormContext db )
        {
            db.SendForms.Add( new SendForm { Award = 120, SityID="12", TaitionFee=120, RentsHostel=120, RentsWithoutF=120, InstitutionID="non", ExpensesWithoutF=120, ExpensesWithF=120, ExpensesHostel=120 } );
            base.Seed( db );
        }
    }
}
