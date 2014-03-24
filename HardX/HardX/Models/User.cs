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

        [Display(Name = "Роль")]
        [Required(ErrorMessage = "* Укажите роль")]
        public Role Role { get; set; }

        public User()
        {
            UserFactory theUserFactory = new UserFactory();
            _repository = theUserFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }

        public static int CurrentUserId
        {
            get
            {
                int userId = 0;
                string strLoginName = HttpContext.Current.User.Identity.Name;
                if (HttpContext.Current.Request.IsAuthenticated)
                {

                }

                return 0;
            }
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