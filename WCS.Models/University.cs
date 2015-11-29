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
        [Key]
        [Display(Name = "ID університету")]
        [ScaffoldColumn( false )]
        public string UniversityID { set; get; }

        [Required( ErrorMessage = "=( Я без області не зможу університет знайти((" )]
        [Display( Name = "ID Області" )]
        public string StateID { set; get; } // зовнішній ключ

        public virtual State State { get; set; } // зв'язок з статеІД
        [ScaffoldColumn( false )]
        [Required, Display(Name = "Університет/Інститут")]
        public string Name { get; set; }
    }
}
