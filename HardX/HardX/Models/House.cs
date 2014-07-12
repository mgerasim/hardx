using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Core;
using HardX.Factories;

namespace HardX.Models
{
    public class House : Entity<House>
    {       
        public Int32 ID {get; set;}
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]        
        [Editable(true)]
        public virtual string Name { get; set; }

        [Display(Name = "Улица")]
        [Required(ErrorMessage = "* Укажите улицу")]
        public Street Street { get; set; }

        [Display(Name = "Площадка")]
        public Area Area { get; set; }

        public string FullName
        {
            get
            {
                return this.Street.Town.Name +", " + this.Street.Name + ", " + this.Name;
            }
        }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public int Creater { get; set; }
        public int Updater { get; set; }

        public override void Save(House entity)
        {
            this.Created_At = DateTime.Now;
            this.Updated_At = DateTime.Now;
            this.Creater = User.CurrentUserId;
            this.Updater = User.CurrentUserId;
            base.Save(entity);
        }

        public override void Update(House entity)
        {
            this.Updated_At = DateTime.Now;
            this.Updater = User.CurrentUserId;
            base.Update(entity);
        }

        public House()
        {
            HouseFactory theFactory = new HouseFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }       
    }

    public class HouseNew : House
    {
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]        
        [Editable(true)]
        public override string Name { get; set; }        
    }
}