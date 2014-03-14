﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Core;
using HardX.Factories;

namespace HardX.Models
{
    public class Material : Entity<Material>
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

        public int StatusID;


        [Display(Name = "Количество")]
        [Required(ErrorMessage = "* Укажите количество")]
        public int Count { get; set; }

       
                
        public Material()
        {
            MaterialFactory theFactory = new MaterialFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }
    }
}