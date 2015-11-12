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
        /// <summary>
        /// ID записи в базе данных
        public int Id { get; set; }
        [ScaffoldColumn( false )]
        public string NoteID { private set; get; }
        /// ID города
        [Required]
        [Display(Name = "Область")]
        public string SityID { set; get; }
        /// Дата создания записи
        [ScaffoldColumn( false )]
        public DateTime Date { private set; get; }
        /// ID учебного заведения
        [Required]
        [Display( Name = "Учбовий заклад" )]
        public string InstitutionID { set; get; }
        /// Плата за обучение
        [Display( Name = "Плата за навчання" )]
        [DataType( DataType.Currency )]
        public float TaitionFee { set; get; }
        /// Стипендия (какая? / сколько?)
        [Display( Name = "Стипендія" )]
        [DataType( DataType.Currency )]
        public float Award { get; set; }
        /// Дополнительные рассходи если живет с семьей!
        [Display( Name = "Додаткові витрати (за місяць з батьками)" )]
        [DataType( DataType.Currency )]
        public float ExpensesWithF { get; set; }
        /// Дополнительные рассходы если снимаю квартиру!
        [Display( Name = "Додаткові витрати (за місяць знімаючи квартиру)" )]
        [DataType( DataType.Currency )]
        public float ExpensesWithoutF { get; set; }
        /// Дополнительные рассходы если живу в общежитии
        [Display( Name = "Додаткові витрати (за місяць живучи в общазі)" )]
        [DataType( DataType.Currency )]
        public float ExpensesHostel { get; set; }
        /// Плата за жилье если снимаю квартиру
        [Display( Name = "Плата за квартиру (в місяць)" )]
        [DataType( DataType.Currency )]
        public float RentsWithoutF { get; set; }
        /// Плата за общежитиє
        [Display( Name = "Плата за кімнату о общазі (в місяць)" )]
        [DataType( DataType.Currency )]
        public float RentsHostel { get; set; }
        /// Конструктор. Обнуляет некоторые переменные для удобной работы в базе
        public SendForm ()
        {
            TaitionFee = 0;
            Award = 0;
            ExpensesWithF = 0;
            ExpensesWithoutF = 0;
            ExpensesHostel = 0;
            RentsHostel = 0;
            RentsWithoutF = 0;
            Date = DateTime.UtcNow;
        }
        /// </summary>
    }
}
