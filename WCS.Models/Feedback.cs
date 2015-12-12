using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WCS.Models
{
    public class Feedback
    {
        [Key, ScaffoldColumn( false )]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }

        [ScaffoldColumn( false )]
        public DateTime Date { private set; get; }

        [Display( Name = "Ім'я" )]
        [Required( ErrorMessage = "Ви повинні вказати власне ім'я!" )]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Ім'я не відповідає межам [2 - 25] символів")]
        public string Name { get; set; }

        [Display( Name = "Пошта" )]
        [Required( ErrorMessage = "Заповніть будь ласка це поле!" )]
        [StringLength( 50, MinimumLength = 4, ErrorMessage = "Максимальна довжина пошти - 50 символів!" )]
        public string Mail { get; set; }

        [Display( Name = "Відгук" )]
        [Required( ErrorMessage = "Напишіть відгук!" )]
        [StringLength( 1024, MinimumLength = 5, ErrorMessage = "Максимальна кількість символів для цього поля - 1024!" )]
        public string Text { get; set; }
    }
}
