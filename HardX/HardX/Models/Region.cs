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
    public class Region : Entity<Region>
    {       
        public Int32 ID {get; set;}
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }

        [Display(Name = "Регион")]
        [Required(ErrorMessage = "* Укажите регион")]
        public State State { get; set; }
                                
        public Region()
        {
            RegionFactory theFactory = new RegionFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }       
    }

    public class RegionNew : Region
    {
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Remote("IsRegionName_Available", "RegionValidation")]
        [Editable(true)]
        public override string Name { get; set; }
    }
}