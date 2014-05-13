using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Repositories;
using HardX.Core;
using HardX.Factories;
using System.Web.Mvc;

namespace HardX.Models
{
    public partial class Role : Entity<Role>
    {
        private int _Id;
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "* Укажите наименование роли")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* длина наименования должна быть не менее чем 2 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }

        private Iesi.Collections.Generic.ISet<Action> _Actions;

        private Iesi.Collections.Generic.ISet<User> _Users;
                
        public Role()
        {
            RoleFactory theRoleFactory = new RoleFactory();
            _repository = theRoleFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();

            this._Actions = new Iesi.Collections.Generic.HashedSet<Action>();

            this._Users = new Iesi.Collections.Generic.HashedSet<User>();
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
        
        
        public virtual Iesi.Collections.Generic.ISet<Action> Actions
        {
            get
            {
                return this._Actions;
            }
            set
            {
                this._Actions = value;
            }
        }

        public virtual Iesi.Collections.Generic.ISet<User> Users
        {
            get
            {
                return this._Users;
            }
            set
            {
                this._Users = value;
            }
        }

        public virtual Boolean IsExistAction(int actionID)
        {
            foreach (var theAction in this.Actions)
            {
                if (theAction.Id == actionID)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void ClearActions()
        {
            this._Actions.Clear();
        }


        public virtual void ClearUsers()
        {
            this._Users.Clear();
        }

        public virtual Boolean IsExistUser(int userID)
        {
            foreach (var theUser in this.Users)
            {
                if (theUser.Id == userID)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class RoleNew : Role
    {
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "* Укажите наименование роли")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* длина наименования должна быть не менее чем 2 и не более чем 50 символов")]
        [Remote("IsRoleName_Available", "RoleValidation")]
        [Editable(true)]
        public override string Name {get; set;}
    }
}