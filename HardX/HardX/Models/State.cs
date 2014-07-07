using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Factories;
using System.Web.Mvc;
using HardX.Core;

namespace HardX.Models
{
    public class State : Entity<State>
    {       
        public Int32 ID {get; set;}
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }

        [Display(Name = "Филиал")]
        [Required(ErrorMessage = "* Укажите филиал")]
        public Branche Branche { get; set; }

        public string FullName
        {
            get
            {
                return this.Name;
            }
        }
                                
        public State()
        {
            StateFactory theFactory = new StateFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }       
    }

    public class StateNew : State
    {
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Remote("IsStateName_Available", "StateValidation")]
        [Editable(true)]
        public override string Name { get; set; }        
    }
}