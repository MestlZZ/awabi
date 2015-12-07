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

        [ScaffoldColumn( false )]
        public bool IsNaN { get; set; }
        [ScaffoldColumn( false )]
        public bool budjet { get; set; }
        [ScaffoldColumn( false )]
        public int choose { get; set; }

        [Display( Name = "Учбовий заклад" )]
        public string UniversityName { get; set; }
        [Display( Name = "Область / місто" )]
        public string StateName { get; set; }
        [Display( Name = "Стипендія" )]
        public double Award { get; set; }
        [Display( Name = "Плата за навчання" )]
        public double TaitionFee { get; set; }
        [Display( Name = "Плата за кімнату в гуртожитку" )]
        public double RentsDormitory { get; set; }
        [Display( Name = "Плата за зйом квартири" )]
        public double RentsWithoutFamily { get; set; }
        [Display( Name = "Додаткові витрати (проживаючи з батьками)" )]
        public double ExpensesWithFamily { get; set; }
        [Display( Name = "Додаткові витрати (Знімаючи квартиру)" )]
        public double ExpensesWithoutFamily { get; set; }
        [Display( Name = "Додаткові витрати (Проживаючи в гуртожитку)" )]
        public double ExpensesDormitory { get; set; }
        [Display( Name = "Загальний результат" )]
        public double Result { get; set; }
    }
}
