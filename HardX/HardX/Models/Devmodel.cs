using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Core;
using HardX.Factories;
using Iesi.Collections;
using Iesi.Collections.Generic;
using System.Web.Mvc;

namespace HardX.Models
{
    public class Devmodel : Entity<Devmodel>
    {
        public int ID { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "* Укажите наименование оборудования")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* длина полного имени должна быть не менее чем 2 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }

        [Display(Name = "Производитель")]
        [Required(ErrorMessage = "* Укажите производителя")]
        public Vendor Vendor { get; set; }
        [Display(Name = "Производитель")]
        [Required(ErrorMessage = "* Укажите производителя")]
        public int VendorID;

        [Display(Name = "Вид устройства")]
        [Required(ErrorMessage = "* Укажите производителя")]
        public Typedev Typedev { get; set; }
        [Display(Name = "Вид устройства")]
        [Required(ErrorMessage = "* Укажите производителя")]
        public int TypedevID;

        [Display(Name = "Скорость печати")]
        [Required(ErrorMessage = "* Укажите скорость печати")]
        public virtual int Printspeed { get; set; }
        
        [Display(Name = "Ресурс")]
        [Required(ErrorMessage = "* Укажите ресурс")]
        public virtual int Capacity { get; set; }

        public virtual ICollection<Matmodel> Matmodels { get; protected set; }


        public Devmodel()
        {
            Matmodels = new HashedSet<Matmodel>();

            DevmodelFactory theDevmodelFactory = new DevmodelFactory();
            _repository = theDevmodelFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }
    }

    public class NewDevmodel : Devmodel
    {
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "* Укажите наименование оборудования")]
        [Remote("IsDevmodelName_Available", "DevmodelValidation")]
        public override string Name { get; set; }

        [Display(Name = "Скорость печати")]
        [Required(ErrorMessage = "* Укажите скорость печати")]
        [Remote("IsNumber_Available", "DevmodelValidation")]
        public override int Printspeed { get; set; }

        [Display(Name = "Ресурс")]
        [Required(ErrorMessage = "* Укажите ресурс")]
        [Remote("IsNumber_Available", "DevmodelValidation")]
        public override int Capacity { get; set; }

    }
}