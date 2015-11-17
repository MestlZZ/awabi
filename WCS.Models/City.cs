using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS.Models
{
    public class City
    {
        [Key, ScaffoldColumn(false)]
        public string CityID { set; get; }
        [ScaffoldColumn( false )]
        public string StateID { set; get; }
        public virtual State State { get; set; }
        [Required, Display(Name = "Місто")]
        public string Name { get; set; }
    }
}
