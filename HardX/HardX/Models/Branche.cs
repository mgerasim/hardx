using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using HardX.Core;
using Core;
using HardX.Factories;
using System.Web.Mvc;


namespace HardX.Models
{
    public class Branche:Entity<Branche>
    {       
        public Int32 Id {get; set;}
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string FullName { get; set; }
        [Display(Name = "Короткое имя")]
        [Required(ErrorMessage = "* Укажите значение для короткого имени")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "* длина короткого имени должна быть не менее чем 2 и не более чем 10 символов")]
        [Editable(true)]
        public virtual string ShortName { get; set; }
                                
        public Branche()
        {
            BrancheFactory theBrancheFactory = new BrancheFactory();
            _repository = theBrancheFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }       
    }

    public class BrancheNew : Branche
    {
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Remote("IsBranchFullName_Available", "BranchValidation")]
        [Editable(true)]
        public override string FullName { get; set; }
        [Display(Name = "Короткое имя")]
        [Required(ErrorMessage = "* Укажите значение для короткого имени")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "* длина короткого имени должна быть не менее чем 2 и не более чем 10 символов")]
        [Remote("IsBranchShortName_Available", "BranchValidation")]
        [Editable(true)]
        public override string ShortName { get; set; }
    }
}