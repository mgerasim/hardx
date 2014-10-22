using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Factories;
using HardX.Core;

namespace HardX.Models
{
    public class Shippingitemdistribute : Entity<Shippingitemdistribute>
    {
        public virtual Int32 ID  { get; set; }
        public virtual int StoreID { get; set; }
        public virtual int ShippingitemID { get; set; }       
        public virtual int Count { get; set; }
        public virtual int Status { get; set; }
        
        public Shippingitemdistribute()
        {
            ShippingitemdistributeFactory theFactory = new ShippingitemdistributeFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }  
    }
}