using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WCS.Models;

namespace WCS.Databases
{
    public class GetDb
    {
        SendFormContext db = new SendFormContext();
        /*public SendForm GetForm(int Id)
        {
            if (Id == 0)
            {
                return null;
            }
            SendForm send = db.SendForms.Find(Id);
            if (send == null)
            {
                return null;
            }
            return send;
        }*/
    }
}
