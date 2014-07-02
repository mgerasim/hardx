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

        public DateTime Created_At { get; set; }
        
        public int RoomID { get; set; }
        
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
            this.RoomID = entity.RoomID;
            this.StoreID = entity.Store.ID;
            this.StatusID = entity.StatusID;
        }
    }
}