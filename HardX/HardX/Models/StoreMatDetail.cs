using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Factories;
using HardX.Core;
using System.ComponentModel.DataAnnotations;

namespace HardX.Models
{
    public class StoreMatDetail : Entity<StoreMatDetail>
    {
        private int _Id;

        public StoreMatDetail()
        {
            StoreMatDetailFactory theFactory = new StoreMatDetailFactory();
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

        [Display(Name = "Модель расходного оборудования")]
        [Required(ErrorMessage = "* Укажите расходного оборудования")]
        public virtual Matmodel Matmodel { get; set; }
        
        [Display(Name = "Склад")]
        [Required(ErrorMessage = "* Укажите склад")]
        public virtual Store Store { get; set; }

    }
}