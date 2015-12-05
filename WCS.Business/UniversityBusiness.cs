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
    public static class UniversityBusiness
    {
        public static University GetUniversity(string id)
        {
            Universiteties db = new Universiteties();
            return db.Get(id);
        }

        public static string GetUniversityName(string id)
        {
            var univers = GetUniversity(id);
            if (univers == null)
                return null;
            else
                return univers.Name;
        }

        public static IList<University> GetUniversityList()
        {
            Universiteties db = new Universiteties();
            return db.GetList();
        }

        public static int GetLastId()
        {
            var univers = GetUniversityList();
            return univers.Count;
        }

        private static void AddUniversityToDb()
        {
            System.Collections.Generic.List<University> univ = new System.Collections.Generic.List<University>();
            StringBuilder str = new StringBuilder("", 100);
            int lastID = GetLastId();
            University buf = GetUniversity(lastID.ToString());
            Regex newReg = new Regex(@">+[^<]+</a");
            int i = 0;
            int b = 0;
            string sId = (Convert.ToInt32(buf.StateID) + 1).ToString();
            MatchCollection matches = newReg.Matches("");
            foreach (Match mat in matches)
            {
                buf.StateID = sId;
                str.Append(mat.Value);
                str.Remove(0, 1);
                b = str.Length;
                str.Remove((b - 3), 3);
                buf.Name = str.ToString();
                i++;
                buf.UniversityID = (i + lastID).ToString();
                str.Remove(0, str.Length);
                univ.Add(buf);
                buf = new University();
            }
            List<University> univer = new List<University>(univ);
            Universiteties db = new Universiteties();
            db.AddList(univer);
        }

        public static UniversityInfo GetInfo(string univers, bool budjet, int choose)
        {
            UniversityInfo un = new UniversityInfo();
            un.choose = choose;
            un.budjet = budjet;
            un.Result = NotesBusiness.GetAverageNoteForUniversity(univers, budjet, choose);
            un.IsNaN = Double.IsNaN(un.Result);
            un.UniversityName = UniversityBusiness.GetUniversityName(univers);
            un.StateName = StateBusiness.GetStateNameFromUniversity(univers);
            var notes = NotesBusiness.GetListFromUniversity(univers);
            double award = 0, fee = 0, ewf = 0, ewtf = 0, rwtf = 0, rd = 0, ed = 0;
            if (notes.Count != 0)
            {
                foreach (var note in notes)
                {
                    if (budjet)
                    {
                        un.Award += note.Award;
                        if (note.Award != 0)
                            award++;
                    }
                    else
                    {
                        un.TaitionFee += note.TaitionFee;
                        if (note.TaitionFee != 0)
                            fee++;
                    }
                    switch (choose)
                    {
                        case 1:
                            un.ExpensesWithFamily += note.ExpensesWithFamily;
                            if (note.ExpensesWithFamily != 0)
                                ewf++;
                            break;
                        case 3:
                            un.ExpensesDormitory += note.ExpensesDormitory;
                            if (note.ExpensesDormitory != 0)
                                ed++;
                            un.RentsDormitory += note.RentsDormitory;
                            if (note.RentsDormitory != 0)
                                rd++;
                            break;
                        case 2:
                            un.ExpensesWithoutFamily += note.ExpensesWithoutFamily;
                            if (note.ExpensesWithoutFamily != 0)
                                ewtf++;
                            un.RentsWithoutFamily += note.RentsWithoutFamily;
                            if (note.RentsWithoutFamily != 0)
                                rwtf++;
                            break;
                        default:
                            break;
                    }
                }
                if (budjet)
                    un.Award /= award;
                else
                    un.TaitionFee /= fee;
                switch (choose)
                {
                    case 1:
                        un.ExpensesWithFamily /= ewf;
                        break;
                    case 3:
                        un.ExpensesDormitory /= ed;
                        un.RentsDormitory /= rd;
                        break;
                    case 2:
                        un.ExpensesWithoutFamily /= ewtf;
                        un.RentsWithoutFamily /= rwtf;
                        break;
                    default:
                        break;
                }
            }
            return un;
        }
    }
}