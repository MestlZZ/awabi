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

        [Required( ErrorMessage = "Невідома область!" )]
        [Display( Name = "ID Області" )]
        public string StateID { set; get; }

        [ScaffoldColumn( false )]
        [Required, Display(Name = "Університет/Інститут")]
        public string Name { get; set; }
    }
}
