using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Repositories;
using Core;
using HardX.Core;
using HardX.Factories;
using System.Web.Mvc;

namespace HardX.Models
{
    public class User:Entity<User>
    {
        public int Id { get; set; }
        [Display(Name = "Учетная запись")]
        [Required(ErrorMessage = "* Укажите значение для учетной записи")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* длина учетной записи должна быть не менее чем 2 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Login { get; set; }

        [Display(Name = "Филиал")]
        [Required(ErrorMessage = "* Укажите филиал")]
        public Branche Branche{get; set;}

        public int BrancheID;

        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "* Укажите значение для имени пользователя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "* длина имени пользователя должна быть не менее чем 3 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }

        private Iesi.Collections.Generic.ISet<Role> _Roles;

        public User()
        {
            UserFactory theUserFactory = new UserFactory();
            _repository = theUserFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();

            this._Roles = new Iesi.Collections.Generic.HashedSet<Role>();
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

        public static int CurrentUserId
        {
            get
            {
                string strLoginName = HttpContext.Current.User.Identity.Name;
                User theUser = new User();
                List<User> theUserList = new List<User>();
                theUserList = (List<User>)theUser.GetAll("LOGIN = '" + strLoginName + "'");
                if (theUserList.Count == 0 || theUserList.Count >= 2)
                {
                    return 0;
                }
                else
                {
                    return theUserList[0].Id;
                }
            }
        }

        public static string CurrentUserName
        {
            get
            {
                int UserID = User.CurrentUserId;
                if (UserID > 0)
                {
                    User theUser = new User();
                    return theUser.GetById(UserID).Name + " (" + HttpContext.Current.User.Identity.Name + ")";
                }
                else
                {
                    return HttpContext.Current.User.Identity.Name;
                }

            }
        }

        public virtual void ClearRoles()
        {
            this._Roles.Clear();
        }

        public virtual Boolean IsExistRole(int roleID)
        {
            foreach (var theRole in this.Roles)
            {
                if (theRole.Id == roleID)
                {
                    return true;
                }
            }

            return false;
        }

    }

    public class UserNew : User
    {
        [Display(Name = "Учетная запись")]
        [Required(ErrorMessage = "* Укажите значение для учетной записи")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* длина учетной записи должна быть не менее чем 2 и не более чем 50 символов")]
        [Remote("IsUserLogin_Available", "UserValidation")]
        [Editable(true)]
        public override string Login { get; set; }
        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "* Укажите значение для имени пользователя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "* длина имени пользователя должна быть не менее чем 3 и не более чем 50 символов")]
        [Remote("IsUserName_Available", "UserValidation")]
        [Editable(true)]
        public override string Name { get; set; }
    }

}