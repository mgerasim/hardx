using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HardX.Factories;

namespace HardX.Models
{
    public class Shipping : Entity<Shipping>
    {
        public virtual Int32 ID { get; set; }
       
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }
        public virtual Int32 Count { get; set; }

        public Shipping()
        {
            ShippingFactory theFactory = new ShippingFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }  
    }

    public class ShippingNew : Shipping
    {
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Remote("IsShippingName_Available", "ShippingValidation")]
        [Editable(true)]
        public override string Name { get; set; }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           