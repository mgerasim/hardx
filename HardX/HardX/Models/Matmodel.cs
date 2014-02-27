using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Factories;
using HardX.Core;

namespace HardX.Models
{
    public class Matmodel : Entity<Matmodel>
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "* Укажите наименование оборудования")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* длина полного имени должна быть не менее чем 2 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }

        [Display(Name = "Производитель")]
        [Required(ErrorMessage = "* Укажите производителя")]
        public Vendor Vendor { get; set; }

        public int VendorID;

        public string Type;
        
        [Display(Name = "Скорость печати")]
        [Required(ErrorMessage = "* Укажите скорость печати")]
        public string Partnumber { get; set; }
        
        [Display(Name = "Ресурс")]
        [Required(ErrorMessage = "* Укажите ресурс")]
        public int Capacity { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "* Укажите цена")]
        public int Price { get; set; }


        public Matmodel()
        {
            MatmodelFactory theMatmodelFactory = new MatmodelFactory();
            _repository = theMatmodelFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }
    }
}