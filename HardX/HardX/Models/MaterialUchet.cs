using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Factories;
using System.ComponentModel.DataAnnotations;

namespace HardX.Models
{
    public class MaterialUchet : Entity<MaterialUchet>
    {
        public int ID { get; set; }
        [Display(Name = "Полное имя")]
        public virtual string Name { get; set; }
        public int repository_id { get; set; }
        public int count_total { get; set; }
        public int count_issued { get; set; }
        public int count_marriage { get; set; }
        public int count_ordered { get; set; }
        public int count_coming { get; set; }
         
        public MaterialUchet()
        {
            MaterialUchetFactory theFactory = new MaterialUchetFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }
    }
}