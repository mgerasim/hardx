using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Factories;
using HardX.Core;

namespace HardX.Models
{
    public class StoreDevDetail : Entity<StoreDevDetail>
    {
        private int _Id;

        public StoreDevDetail()
        {
            StoreDevDetailFactory theFactory = new StoreDevDetailFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();

        }

        public virtual int ID
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }

        [Display(Name = "Модель оборудования")]
        [Required(ErrorMessage = "* Укажите модель оборудования")]
        public virtual Devmodel Devmodel { get; set; }


        [Display(Name = "Склад")]
        [Required(ErrorMessage = "* Укажите склад")]
        public virtual Store Store { get; set; }

    }
}