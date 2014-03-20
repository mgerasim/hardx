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
    public class Town : Entity<Town>
    {       
        public Int32 ID {get; set;}
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }

        [Display(Name = "Район")]
        [Required(ErrorMessage = "* Укажите район")]
        public Region Region { get; set; }
                                
        public Town()
        {
            TownFactory theFactory = new TownFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }       
    }

    public class TownNew : Town
    {
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Remote("IsTownName_Available", "TownValidation")]
        [Editable(true)]
        public override string Name { get; set; }        
    }
}