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

        public bool IsContract { get; set; }

        public bool IsHaveAward { get; set; }

        public int Choose { get; set; }

        public string UniversityName { get; set; }

        public string StateName { get; set; }

        public double Award { get; set; }

        public double MaximalTaitionFee { get; set; }

        public double MinimalTaitionFee { get; set; }

        public double ExpensesFood { get; set; }

        public double ExpensesTravel { get; set; }

        public double RentsDormitory { get; set; }

        public double RentsApartment { get; set; }

        public double MaximalResult { get; set; }

        public double MinimalResult { get; set; }
    }
}
