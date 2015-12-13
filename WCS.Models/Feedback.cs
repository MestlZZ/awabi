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

        [Display( Name = "Ваше ім'я" )]
        [DataType( DataType.Text )]
        [Required( ErrorMessage = "Будь ласка, вкажіть власне ім'я!" )]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Ім'я має бути в межаї від 2 до 25 символів")]
        public string Name { get; set; }

        [Display( Name = "Адреса вашої пошти" )]
        [DataType( DataType.EmailAddress )]
        [Required( ErrorMessage = "Будь ласка, заповніть це поле!" )]
        [StringLength( 50, MinimumLength = 4, ErrorMessage = "Максимальна довжина адреси не повинно бути більше ніж 50 символів" )]
        public string Mail { get; set; }

        [Display( Name = "Відгук про сервіс" )]
        [DataType( DataType.MultilineText )]
        [Required( ErrorMessage = "Будь ласка, напишіть відгук!" )]
        [StringLength( 1024, MinimumLength = 5, ErrorMessage = "Довжина повідомлення повинна бути в межах від 5 до 1024 символів" )]
        public string Text { get; set; }

        public Feedback()
        {
            Date = DateTime.UtcNow;
        }
    }
}
