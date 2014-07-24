using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Core;

namespace HardX.Models.Base
{
    public class MaterialBase : Entity<Material>
    {
        public int ID { get; set; }

        [Display(Name = "Модель расходного материала")]
        [Required(ErrorMessage = "* Укажите модель расходного материала")]
        public Matmodel Matmodel { get; set; }
                
        [Display(Name = "Склад")]
        [Required(ErrorMessage = "* Укажите склад")]
        public Store Store { get; set; }
                
        [Display(Name = "Статус")]
        [Required(ErrorMessage = "* Укажите статус")]
        public int StatusID { get; set; }

        [Display(Name = "На какой склад выдан?")]
        public int StoreIssuedID { get; set; }
                
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public int Creater { get; set; }
        public int Updater { get; set; }

        public String CauseOfMarriage { get; set; }

        public int DeviceSetupID { get; set; }
    }
}