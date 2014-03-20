using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using System.ComponentModel.DataAnnotations;
using HardX.Factories;
using System.Web.Mvc;

namespace HardX.Models
{
    public class Street : Entity<Street>
    {       
        public Int32 ID {get; set;}
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }

        [Display(Name = "Населённый пункт")]
        [Required(ErrorMessage = "* Укажите населённый пункт")]
        public Town Town { get; set; }
                                
        public Street()
        {
            StreetFactory theFactory = new StreetFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }       
    }

    public class StreetNew : Street
    {
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]        
        [Editable(true)]
        public override string Name { get; set; }        
    }
}