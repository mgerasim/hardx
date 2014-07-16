using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Factories;
using System.ComponentModel.DataAnnotations;
using HardX.Core;

namespace HardX.Models.Base
{
    public class DeviceBase : Entity<Device>
    {
        public int ID { get; set; }

        [Display(Name = "Модель оборудования")]
        [Required(ErrorMessage = "* Укажите модель оборудования")]
        public Devmodel Devmodel { get; set; }

        [Display(Name = "Серийный номер")]
        [Required(ErrorMessage = "* Укажите серийный номер")]
        public String Serial { get; set; }
        
        [Display(Name = "IP Адрес")]
        [Required(ErrorMessage = "* Укажите IP адрес")]
        public String IPAddr { get; set; }
        
        [Display(Name = "Хост")]
        [Required(ErrorMessage = "* Укажите хост")]
        public String Host{ get; set; }
                
        [Display(Name = "Склад")]
        [Required(ErrorMessage = "* Укажите склад")]
        public Store Store { get; set; }

        [Display(Name = "Где установлен?")]
        [Required(ErrorMessage = "* Укажите комнату установки")]
        public int RoomSetupID { get; set; }

        [Display(Name = "Статус")]
        [Required(ErrorMessage = "* Укажите статус")]
        public int StatusID { get; set; }

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public int Creater { get; set; }
        public int Updater { get; set; }

        public String CauseOfMarriage { get; set; }
                
        public string FullName
        {
            get
            {
                return this.Devmodel.FullName + " # " + this.ID ;                
            }
        }

        
    }
}