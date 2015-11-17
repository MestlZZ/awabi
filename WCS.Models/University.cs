using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS.Models
{
    class University
    {
        /// [DatabaseGenerated(DatabaseGeneratedOption.Identity)] if it will have int type
        [Key, Required, Display(Name = "ID університету")]
        public string UniversityID { set; get; }
        public string CityID { get; set; }
        public virtual City City { get; set; }
        [Required, Display(Name = "Університет/Інститут")]
        public string Name { get; set; }
    }
}
