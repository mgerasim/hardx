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

        public int MatmodelID;


        [Display(Name = "Склад")]
        [Required(ErrorMessage = "* Укажите склад")]
        public Store Store { get; set; }

        public int StoreID;


        [Display(Name = "Статус")]
        [Required(ErrorMessage = "* Укажите статус")]
        public Status Status { get; set; }

        public int StatusID { get; set; }

        [Display(Name = "Добавить позицию этого материала")]
        public bool fAdded { get; set; }

        [Display(Name = "Количество")]
        [Required(ErrorMessage = "* Укажите количество")]
        public int Count { get; set; }


        [Display(Name = "Выдать")]
        [Required(ErrorMessage = "* Укажите количество для выдачи")]
        public int CountIssued { get; set; }

        [Display(Name = "В брак")]
        [Required(ErrorMessage = "* Укажите количество как брак")]
        public int CountMarriage { get; set; }

        [Display(Name = "Удалить")]
        [Required(ErrorMessage = "* Укажите количество для удаления")]
        public int CountDelete { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

        public String CauseOfMarriage { get; set; }

        public int DeviceID { get; set; }
    }
}