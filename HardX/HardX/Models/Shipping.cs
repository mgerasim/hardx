using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HardX.Factories;

namespace HardX.Models
{
    public class Shipping : Entity<Shipping>
    {
        public virtual Int32 ID { get; set; }
       
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Editable(true)]
        public virtual string Name { get; set; }
        public virtual Int32 Count { get; set; }

        public virtual DateTime Created_At { get; set; }
        public virtual int Creater { get; set; }

        public override void Save(Shipping entity)
        {
            this.Created_At = DateTime.Now;
            this.Creater = User.CurrentUserId;
            base.Save(entity);
        }

        public override void Update(Shipping entity)
        {
            base.Update(entity);
        }

        private Iesi.Collections.Generic.ISet<Shippingitem> _Shippingitems;

        public virtual Iesi.Collections.Generic.ISet<Shippingitem> Shippingitems
        {
            get
            {
                return this._Shippingitems;
            }
            set
            {
                this._Shippingitems = value;
            }
        }

        public Shipping()
        {
            this._Shippingitems = new Iesi.Collections.Generic.HashedSet<Shippingitem>();
        
            ShippingFactory theFactory = new ShippingFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }  
    }

    public class ShippingNew : Shipping
    {
        [Display(Name = "Полное имя")]
        [Required(ErrorMessage = "* Укажите значение для полного имени")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "* длина полного имени должна быть не менее чем 5 и не более чем 50 символов")]
        [Remote("IsShippingName_Available", "ShippingValidation")]
        [Editable(true)]
        public override string Name { get; set; }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           