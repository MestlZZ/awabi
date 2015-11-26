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
            Required( ErrorMessage = "Поле не повинно бути порожнім!" ),
            Display( Name = "Учбовий заклад" )
        ]
        public string UniversityID { set; get; } // зовнішній ключ

        public virtual University University { get; set; } // зв'язок з university

        [ScaffoldColumn( false )]
        public DateTime Date { private set; get; }

        [
            Display( Name = "Плата за навчання" ), 
            DataType( DataType.Currency ), 
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" ),
            Required( ErrorMessage = "Поле не повинно бути порожнім!" )
        ]
        public double TaitionFee { set; get; }

        [
            Display( Name = "Стипендія" ), 
            DataType( DataType.Currency ), 
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" ),
            Required( ErrorMessage = "Поле не повинно бути порожнім!" )
        ]
        public double Award { get; set; }

        [
            Display( Name = "Додаткові витрати (за місяць проживання з батьками)" ), 
            DataType( DataType.Currency ), 
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" ),
            Required( ErrorMessage = "Поле не повинно бути порожнім!" )
        ]
        public double ExpensesWithF { get; set; }

        [
            Display( Name = "Додаткові витрати (за місяць знімаючи квартиру)" ), 
            DataType( DataType.Currency ), 
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" ),
            Required( ErrorMessage = "Поле не повинно бути порожнім!" )
        ]
        public double ExpensesWithoutF { get; set; }

        [
            Display( Name = "Додаткові витрати (за місяць проживаючи у гуртожитку)" ), 
            DataType( DataType.Currency ), 
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" ),
            Required( ErrorMessage = "Поле не повинно бути порожнім!" )
        ]
        public double ExpensesHostel { get; set; }

        [
            Display( Name = "Плата за квартиру (у місяць)" ), 
            DataType( DataType.Currency ), 
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" ),
            Required( ErrorMessage = "Поле не повинно бути порожнім!" )
        ]
        public double RentsWithoutF { get; set; }

        [
            Display( Name = "Плата за кімнату у гуртожитку (у місяць)" ), 
            DataType( DataType.Currency ), 
            Range( 0.0, 50000.0, ErrorMessage = "Неприпустиме значення" ),
            Required( ErrorMessage = "Поле не повинно бути порожнім!" )
        ]
        public double RentsHostel { get; set; }
        public Note ()
        {
            Date = DateTime.UtcNow;
        }
    }
}
