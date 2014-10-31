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

        public virtual DateTime Created_At { get; set; }
        public virtual DateTime Updated_At { get; set; }
        public virtual int Creater { get; set; }
        public virtual int Updater { get; set; }

        public override void Save(Shippingitemdistribute entity)
        {
            this.Created_At = DateTime.Now;
            this.Updated_At = DateTime.Now;
            this.Creater = User.CurrentUserId;
            this.Updater = User.CurrentUserId;
            base.Save(entity);

        }

        public override void Update(Shippingitemdistribute entity)
        {
            this.Updated_At = DateTime.Now;
            this.Updater = User.CurrentUserId;
            base.Update(entity);
        }
                      
        public Shippingitemdistribute()
        {
            ShippingitemdistributeFactory theFactory = new ShippingitemdistributeFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }  
    }
}