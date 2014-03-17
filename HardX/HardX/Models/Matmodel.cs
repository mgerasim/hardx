using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Factories;
using HardX.Core;
using Iesi.Collections.Generic;
using System.Web.Mvc;

namespace HardX.Models
{
    public class Matmodel : Entity<Matmodel>
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


        [Display(Name = "Вид расходного материала")]
        [Required(ErrorMessage = "* Укажите вид расходного материала")]
        public Typedev Typedev { get; set; }
        [Display(Name = "Вид расходного материала")]
        [Required(ErrorMessage = "* Укажите вид расходного материала")]
        public int TypedevID;



        public string Type;
        
        [Display(Name = "Модель")]
        [Required(ErrorMessage = "* Укажите модель")]
        public string Partnumber { get; set; }
        
        [Display(Name = "Ресурс")]
        [Required(ErrorMessage = "* Укажите ресурс")]
        public int Capacity { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "* Укажите цена")]
        public int Price { get; set; }

        public virtual ICollection<Devmodel> Devmodels { get; protected set; }

        public string FullName
        {
            get
            {
                return this.Vendor.Name + " " + this.Partnumber + " " + this.Name;
            }
        }

        public Matmodel()
        {
            Devmodels = new HashedSet<Devmodel>();

            MatmodelFactory theMatmodelFactory = new MatmodelFactory();
            _repository = theMatmodelFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }
    }

    public class NewMatmodel : Matmodel
    {
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "* Укажите наименование расходного материала")]
        [Remote("IsMatmodelName_Available", "MatmodelValidation")]
        [Editable(true)]
        public override string Name { get; set; }
    }
}