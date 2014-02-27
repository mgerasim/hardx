using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Core;
using HardX.Factories;

namespace HardX.Models
{
    public class Vendor : Entity<Vendor>
    {
        public Int32 Id { get; set; }
        [Display(Name = "Наименование производителя")]
        [Required(ErrorMessage = "* Укажите нименование производителя")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "* длина полного имени должна быть не менее чем 1 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }

        public Vendor()
        {
            VendorFactory theVendorFactory = new VendorFactory();
            _repository = theVendorFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }
    }
}