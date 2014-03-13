using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HardX.Models
{
    public class Status
    {
        public int ID { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "* Укажите наименование статуса")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* длина полного имени должна быть не менее чем 2 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }
    }
}