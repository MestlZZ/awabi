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
    public class SendForm
    {
        [Key, ScaffoldColumn( false )]
        public string Id { get; set; }
        [Required, Display(Name = "ID Області")]
        public string StateID { set; get; } // зовнішній ключ
        public virtual State State { get; set; } // зв'язок з статеІД
        [ScaffoldColumn( false )]
        public DateTime Date { private set; get; }
        [Required, Display( Name = "Учбовий заклад" )]
        public string InstitutionID { set; get; }
        [Display( Name = "Плата за навчання" ), DataType( DataType.Currency )]
        public decimal? TaitionFee { set; get; }
        [Display( Name = "Стипендія" ), DataType( DataType.Currency )]
        public decimal? Award { get; set; }
        [Display( Name = "Додаткові витрати (за місяць з батьками)" ), DataType( DataType.Currency )]
        public decimal? ExpensesWithF { get; set; }
        [Display( Name = "Додаткові витрати (за місяць знімаючи квартиру)" ), DataType( DataType.Currency )]
        public decimal? ExpensesWithoutF { get; set; }
        [Display( Name = "Додаткові витрати (за місяць живучи в общазі)" ), DataType( DataType.Currency )]
        public decimal? ExpensesHostel { get; set; }
        [Display( Name = "Плата за квартиру (в місяць)" ), DataType( DataType.Currency )]
        public decimal? RentsWithoutF { get; set; }
        [Display( Name = "Плата за кімнату о общазі (в місяць)" ), DataType( DataType.Currency )]
        public decimal? RentsHostel { get; set; }
        public SendForm ()
        {
            Date = DateTime.UtcNow;
        }
    }
}
