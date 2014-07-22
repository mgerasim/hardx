using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HardX.Models.NonTables
{
    public class Deviceadded
    {
        [RegularExpression(@"^\d+$", ErrorMessage = "Укажите количетво нового оборудования.")]
        [Required]
        [Display(Name = "Количество")]
        public virtual int count { get; set; }

        [Required]
        [Display(Name = "Модель оборудования")]
        public virtual int model { get; set; }
    }
}