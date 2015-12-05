using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS.Models
{
    public class UniversityInfo
    {
        [UIHint( "Search_Univer" )]
        [DisplayFormat( NullDisplayText = "" )]
        [DataType( DataType.Currency )]
        [Required( ErrorMessage = "Поле не повинно бути порожнім!" )]
        [Display( Name = "Учбовий заклад" )]
        [ScaffoldColumn( false )]
        public string UniversityID { set; get; }

        public bool IsNaN { get; set; }
        public string UniversityName { get; set; }
        public string StateName { get; set; }
        public double Award { get; set; }
        public double TaitionFee { get; set; }
        public double RentsDormitory { get; set; }
        public double RentsWithoutFamily { get; set; }
        public double ExpensesWithFamily { get; set; }
        public double ExpensesWithoutFamily { get; set; }
        public double ExpensesDormitory { get; set; }
        public double Result { get; set; }
    }
}
