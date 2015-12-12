using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WCS.Models
{
    public class Note
    {
        [Key, ScaffoldColumn( false )]
        public string Id { get; set; }

        [UIHint( "Search_Univer" )]
        [DisplayFormat( NullDisplayText = "" )]
        [DataType(DataType.Currency)]
        [Required( ErrorMessage = "Поле не повинно бути порожнім!" )]
        [Display( Name = "Учбовий заклад" )]
        public string UniversityID { set; get; }

        [ScaffoldColumn( false )]
        public DateTime Date { private set; get; }

        [Display( Name = "Максимальна плата за навчання" )]
        [DataType( DataType.Currency, ErrorMessage = "Тут мають бути лише цифри!" )] 
        [Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )]
        [Required( ErrorMessage = "Поле не повинно бути порожнім!" )]
        public double MaximalTaitionFee { set; get; }

        [Display( Name = "Мінімальна плата за навчання" )]
        [DataType( DataType.Currency, ErrorMessage = "Тут мають бути лише цифри!" )]
        [Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )]
        [Required( ErrorMessage = "Поле не повинно бути порожнім!" )]
        public double MinimalTaitionFee { set; get; }

        [Display( Name = "Витрати на їжу (в місяць)" )]
        [DataType( DataType.Currency, ErrorMessage = "Тут мають бути лише цифри!" )]
        [Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )]
        [Required( ErrorMessage = "Поле не повинно бути порожнім!" )]
        public double ExpensesFood { get; set; }

        [Display( Name = "Витрати за проїзд (в місяць)" )]
        [DataType( DataType.Currency, ErrorMessage = "Тут мають бути лише цифри!" )]
        [Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )]
        [Required( ErrorMessage = "Поле не повинно бути порожнім!" )]
        public double ExpensesTravel { get; set; }

        [Display( Name = "Плата за кімнату у гуртожитку (у місяць)" )]
        [DataType( DataType.Currency, ErrorMessage = "Тут мають бути лише цифри!" )]
        [Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )]
        [Required( ErrorMessage = "Поле не повинно бути порожнім!" )]
        public double RentsDormitory { get; set; }

        [Display( Name = "Плата за квартиру (у місяць)" )]
        [DataType( DataType.Currency, ErrorMessage = "Тут мають бути лише цифри!" )]
        [Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )]
        [Required( ErrorMessage = "Поле не повинно бути порожнім!" )]
        public double RentsApartment { get; set; }

        public Note ()
        {
            Date = DateTime.UtcNow;
        }
    }
}
