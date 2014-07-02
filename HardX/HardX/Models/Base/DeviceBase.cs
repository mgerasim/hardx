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

        public int DevmodelID;


        [Display(Name = "Склад")]
        [Required(ErrorMessage = "* Укажите склад")]
        public Store Store { get; set; }

        public int StoreID;


        [Display(Name = "Статус")]
        [Required(ErrorMessage = "* Укажите статус")]
        public int StatusID { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

        public String CauseOfMarriage { get; set; }

        public int RoomID { get; set; }

        public string FullName
        {
            get
            {
                return this.Devmodel.FullName + "(#" + this.ID + ")";
            }
        }

        
    }
}