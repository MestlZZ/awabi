using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS.Models
{
    public class University
    {
        /// [DatabaseGenerated(DatabaseGeneratedOption.Identity)] if it will have int type
        [UIHint( "Search_Univer" )]
        [DisplayFormat( NullDisplayText = "" )]
        [DataType( DataType.Currency )]
        [Required( ErrorMessage = "Поле не повинно бути порожнім!" )]
        [Display( Name = "Учбовий заклад" )]
        [ScaffoldColumn( false )]
        public string UniversityID { set; get; }

        [Required( ErrorMessage = "Невідома область!" )]
        [Display( Name = "ID Області" )]
        public string StateID { set; get; }

        [ScaffoldColumn( false )]
        [Required, Display(Name = "Університет/Інститут")]
        public string Name { get; set; }
    }
}
