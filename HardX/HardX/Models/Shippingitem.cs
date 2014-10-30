using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Core;
using HardX.Factories;

namespace HardX.Models
{
    public class Shippingitem : Entity<Shippingitem>
    {
        public virtual Int32 ID  { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual Devmodel Devmodel { get; set; }
        public virtual Matmodel Matmodel { get; set; }
        public virtual int Count { get; set; }

        private Iesi.Collections.Generic.ISet<Shippingitemdistribute> _Distributes;

        public virtual Iesi.Collections.Generic.ISet<Shippingitemdistribute> Distributes
        {
            get
            {
                return this._Distributes;
            }
            set
            {
                this._Distributes = value;
            }
        }

        private Iesi.Collections.Generic.ISet<Store> _Stores;
        public virtual Iesi.Collections.Generic.ISet<Store> Stores
        {
            get
            {
                return this._Stores;
            }
            set
            {
                this._Stores = value;
            }
        }

        public Shippingitem()
        {
            this._Distributes = new Iesi.Collections.Generic.HashedSet<Shippingitemdistribute>();

            ShippingitemFactory theFactory = new ShippingitemFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();

            this._Stores = new Iesi.Collections.Generic.HashedSet<Store>();
        }  
    }
}