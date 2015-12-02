using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS.Models;
using WCS.Databases;

namespace WCS.Business
{
    public static class NotesBusiness
    {
        public static IList<Note> GetList()
        {
            Notes db = new Notes();
            return db.GetList();
        }

        private static double GetAverage( int ind )
        {
            Notes db = new Notes();
            double sum = 0;

            var notes = db.GetList();

            if (notes.Count != 0)
            {
                foreach (var note in notes)
                {
                    switch (ind)
                    {
                        case 1:
                            sum += note.TaitionFee;
                            break;
                        case 2:
                            sum += note.Award;
                            break;
                        case 3:
                            sum += note.ExpensesWithFamily;
                            break;
                        case 4:
                            sum += note.ExpensesWithoutFamily;
                            break;
                        case 5:
                            sum += note.ExpensesDormitory;
                            break;
                        case 6:
                            sum += note.RentsWithoutFamily;
                            break;
                        case 7:
                            sum += note.RentsDormitory;
                            break;
                        default:
                            return 0;
                    }
                }

                sum = sum / (double)notes.Count;
            }

            return sum;
        }

        public static double GetAverageFee()
        {
            return GetAverage( 1 );
        }

        public static double GetAverageAward()
        {
            return GetAverage( 2 );
        }

        public static double GetAverageExpensesWithFamily()
        {
            return GetAverage( 3 );
        }

        public static double GetAverageExpensesWithoutFamily()
        {
            return GetAverage( 4 );
        }

        public static double GetAverageExpensesDormitory()
        {
            return GetAverage( 5 );
        }

        public static double GetAverageRentsWithoutFamily()
        {
            return GetAverage( 6 );
        }

        public static double GetAverageRentsDormitory()
        {
            return GetAverage( 7 );
        }

        public static double GetAverageWithFamily()
        {
            double sum = 0;
            sum += GetAverageExpensesWithFamily();
            return sum;
        }

        public static double GetAverageWithoutFamily()
        {
            double sum = 0;
            sum += GetAverageExpensesWithoutFamily();
            sum += GetAverageRentsWithoutFamily();
            return sum;
        }

        public static double GetAverageDormitory()
        {
            double sum = 0;
            sum += GetAverageExpensesDormitory();
            sum += GetAverageRentsDormitory();
            return sum;
        }

        public static double GetAverageAll( bool budjet, int choose )
        {
            double sum = 0;
            if (budjet)
                sum += GetAverageAward();
            else
                sum -= GetAverageFee();
            switch(choose)
            {
                case 1:
                    sum += GetAverageWithFamily();
                    break;
                case 2:
                    sum += GetAverageWithoutFamily();
                    break;
                case 3:
                    sum += GetAverageDormitory();
                    break;
                default:
                    break;
            }
            return sum;
        }
        public static double GetAverageAll( string id )
        {
            Notes db = new Notes();
            var note = db.Get( id );
            double sum = 0;
            sum += note.RentsWithoutFamily + note.RentsDormitory;
            sum += note.ExpensesWithoutFamily + note.ExpensesWithFamily + note.ExpensesDormitory;
            sum += note.Award - note.TaitionFee;
            return sum;
        }

        public static University GetUniversity( string id )
        {
            Universiteties db = new Universiteties();
            return db.Get( id );
        }

        public static State GetState( string id )
        {
            States db = new States();
            return db.Get( id );
        }

        public static string GetUniversityName( string id )
        {
            var univers = GetUniversity( id );
            return univers.Name;
        }

        public static string GetStateName( string id )
        {
            var univers = GetUniversity( id );
            var state = GetState( univers.StateID );
            return state.Name;
        }
    }
}
