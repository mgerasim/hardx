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

       

        public Shippingitem()
        {
            ShippingitemFactory theFactory = new ShippingitemFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }  
    }
}