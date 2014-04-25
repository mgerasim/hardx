using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Factories;
using System.Web.Mvc;
using HardX.Core;
using Iesi.Collections.Generic;

namespace HardX.Models
{
    public class Area:Entity<Area>
    {       
        public Int32 Id {get; set;}
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }

        public virtual ICollection<Room> Rooms { get; protected set; }

        public Area()
        {
            Rooms = new HashedSet<Room>();
            AreaFactory theBrancheFactory = new AreaFactory();
            _repository = theBrancheFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }

        [Display(Name = "Кладовщик")]
        [Required(ErrorMessage = "* Укажите кладовщика")]
        public User User { get; set; }
    }

    public class AreaNew : Area
    {
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Remote("IsAreaName_Available", "AreaValidation")]
        [Editable(true)]
        public override string Name { get; set; }       
    }
}