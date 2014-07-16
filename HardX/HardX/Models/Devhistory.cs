using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Factories;

namespace HardX.Models
{
    public class Devhistory : Entity<Devhistory>
    {
        public int ID { get; set; }

        public int DeviceID { get; set; }

        public int StoreID { get; set; }        

        public int StatusID { get; set; }

        public int DevmodelID { get; set; }
                
        public int RoomID { get; set; }

        public String Serial { get; set; }

        public String IPAddr { get; set; }

        public String Host { get; set; }

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public int Creater { get; set; }
        public int Updater { get; set; }

        public override void Save(Devhistory entity)
        {
            this.Created_At = DateTime.Now;
            this.Updated_At = DateTime.Now;
            this.Creater = User.CurrentUserId;
            this.Updater = User.CurrentUserId;
            base.Save(entity);
        }

        public override void Update(Devhistory entity)
        {
            this.Updated_At = DateTime.Now;
            this.Updater = User.CurrentUserId;
            base.Update(entity);
        }
        
        public Devhistory()
        {
            this.Created_At = DateTime.Now;

            DevhistoryFactory theFactory = new DevhistoryFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }

        public Devhistory(Device entity) : this()
        {
            this.DeviceID = entity.ID;
            this.Created_At = entity.Created_At;
            this.RoomID = entity.RoomSetupID;
            this.StoreID = entity.Store.ID;
            this.StatusID = entity.StatusID;
            this.Serial = entity.Serial;
            this.IPAddr = entity.IPAddr;
            this.Host = entity.Host;
            this.DevmodelID = entity.Devmodel.ID;
        }
    }
}