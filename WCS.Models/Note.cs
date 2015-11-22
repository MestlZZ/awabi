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

        [
            Required( ErrorMessage = "Ну і яку інформацію ви шукаєте без цього поля? =)" ),
            Display( Name = "Учбовий заклад" )
        ]
        public string UniversityID { set; get; } // зовнішній ключ

        public virtual University University { get; set; } // зв'язок з university

        [ScaffoldColumn( false )]
        public DateTime Date { private set; get; }

        [
            Display( Name = "Плата за навчання" ), 
            DataType( DataType.Currency ), 
            RegularExpression( @"[0-9]", ErrorMessage = "Тут повинні бути лише цифри =)" ),
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )
            
        ]
        public double TaitionFee { set; get; }

        [
            Display( Name = "Стипендія" ), 
            DataType( DataType.Currency ), 
            RegularExpression( @"[0-9]", ErrorMessage = "Тут повинні бути лише цифри =)" ),
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )
        ]
        public double Award { get; set; }

        [
            Display( Name = "Додаткові витрати (за місяць з батьками)" ), 
            DataType( DataType.Currency ), 
            RegularExpression( @"[0-9]", ErrorMessage = "Тут повинні бути лише цифри =)" ),
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )
        ]
        public double ExpensesWithF { get; set; }

        [
            Display( Name = "Додаткові витрати (за місяць знімаючи квартиру)" ), 
            DataType( DataType.Currency ), 
            RegularExpression( @"[0-9]", ErrorMessage = "Тут повинні бути лише цифри =)" ),
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )
        ]
        public double ExpensesWithoutF { get; set; }

        [
            Display( Name = "Додаткові витрати (за місяць живучи в общазі)" ), 
            DataType( DataType.Currency ), 
            RegularExpression( @"[0-9]", ErrorMessage = "Тут повинні бути лише цифри =)" ),
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )
        ]
        public double ExpensesHostel { get; set; }

        [
            Display( Name = "Плата за квартиру (в місяць)" ), 
            DataType( DataType.Currency ), 
            RegularExpression( @"[0-9]", ErrorMessage = "Тут повинні бути лише цифри =)" ),
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )
        ]
        public double RentsWithoutF { get; set; }

        [
            Display( Name = "Плата за кімнату о общазі (в місяць)" ), 
            DataType( DataType.Currency ), 
            RegularExpression( @"[0-9]", ErrorMessage = "Тут повинні бути лише цифри =)" ),
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" )
        ]
        public double RentsHostel { get; set; }
        public Note ()
        {
            Date = DateTime.UtcNow;
        }
    }
}
