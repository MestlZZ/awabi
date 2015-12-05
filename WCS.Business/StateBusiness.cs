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
    public static class StateBusiness
    {
        public static State GetState( string id )
        {
            States db = new States();
            return db.Get( id );
        }

        public static string GetStateName( string id )
        {
            var univers = UniversityBusiness.GetUniversity( id );
            var state = GetState( univers.StateID );
            return state.Name;
        }
    }
}
