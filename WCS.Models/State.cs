﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS.Models
{
    public class State
    {
        [Key]
        [ScaffoldColumn(false)]
        public int StateID { set; get; }
        [Required]
        [Display(Name = "Область")]
        public string Name { get; set; }
    }
}
