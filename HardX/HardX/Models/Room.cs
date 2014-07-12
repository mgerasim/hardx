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



        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public int Creater { get; set; }
        public int Updater { get; set; }

        public override void Save(Room entity)
        {
            this.Created_At = DateTime.Now;
            this.Updated_At = DateTime.Now;
            this.Creater = User.CurrentUserId;
            this.Updater = User.CurrentUserId;
            base.Save(entity);
        }

        public override void Update(Room entity)
        {
            this.Updated_At = DateTime.Now;
            this.Updater = User.CurrentUserId;
            base.Update(entity);
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