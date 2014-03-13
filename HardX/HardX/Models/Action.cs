using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Core;
using HardX.Factories;

namespace HardX.Models
{
    public class Action:Entity<Action>
    {
        private int _Id;
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "* Укажите наименование доступа")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* длина наименования должна быть не менее чем 2 и не более чем 50 символов")]
        [Editable(true)]
        private string _Name;

        private Iesi.Collections.Generic.ISet<Role> _Roles;
      
        public Action()
        {
            ActionFactory theActionFactory = new ActionFactory();
            _repository = theActionFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();

        }

        public virtual int Id
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

        public virtual string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        public virtual Iesi.Collections.Generic.ISet<Role> Roles
        {
            get
            {
                return this._Roles;
            }
            set
            {
                this._Roles = value;
            }
        }
    }
}