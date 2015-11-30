using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS.Models
{
    public class State
    {
        /// [DatabaseGenerated(DatabaseGeneratedOption.Identity)] if it will have int type
        [Key]
        [Display(Name = "ID області")]
        [ScaffoldColumn( false )]
        public string StateID { set; get; }

        [Required]
        [Display( Name = "Область" )]
        public string Name { get; set; }
    }
}
