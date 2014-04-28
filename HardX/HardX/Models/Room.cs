using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using System.ComponentModel.DataAnnotations;
using HardX.Factories;

namespace HardX.Models
{
    public class Room : Entity<Room>
    {       
        public Int32 ID {get; set;}
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]        
        [Editable(true)]
        public virtual string Name { get; set; }

        [Display(Name = "Здание")]
        [Required(ErrorMessage = "* Укажите здание")]
        public House House { get; set; }        

        public string FullName
        {
            get
            {
                return this.House.FullName + ", " + this.Name;
            }
        }
                        
        public Room()
        {
            RoomFactory theFactory = new RoomFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }       
    }

    public class RoomNew : Room
    {
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]        
        [Editable(true)]
        public override string Name { get; set; }        
    }
}