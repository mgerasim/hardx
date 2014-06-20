using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using System.ComponentModel.DataAnnotations;
using HardX.Factories;

namespace HardX.Models
{
    public class Device: Entity<Device>
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
        public Status Status { get; set; }

        public int StatusID { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }
                
        public Device()
        {
            this.Created_At = DateTime.Now;
            this.Updated_At = DateTime.Now;
            DeviceFactory theFactory = new DeviceFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }
    }
}