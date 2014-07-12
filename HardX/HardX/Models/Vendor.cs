using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Core;
using HardX.Factories;
using HardX.Models.Base;

namespace HardX.Models
{
    public class Vendor : Entity<Vendor>
    {
        public Int32 Id { get; set; }
        [Display(Name = "Наименование производителя")]
        [Required(ErrorMessage = "* Укажите нименование производителя")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "* длина полного имени должна быть не менее чем 1 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public int Creater { get; set; }
        public int Updater { get; set; }

        public override void Save(Vendor entity)
        {
            this.Created_At = DateTime.Now;
            this.Updated_At = DateTime.Now;
            this.Creater = User.CurrentUserId;
            this.Updater = User.CurrentUserId;
            base.Save(entity);
        }

        public override void Update(Vendor entity)
        {
            this.Updated_At = DateTime.Now;
            this.Updater = User.CurrentUserId;
            base.Update(entity);
        }
        
        public Vendor()
        {   
            VendorFactory theVendorFactory = new VendorFactory();
            _repository = theVendorFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }
    }
}