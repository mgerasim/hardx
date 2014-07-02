using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Factories;
using HardX.Core;

namespace HardX.Models
{
    public class Mathistory : Entity<Mathistory>
    {
        public int ID { get; set; }

        public int MaterialID { get; set; }
        public int DeviceID { get; set; }

        public int StoreID { get; set; }

        public int StatusID { get; set; }

        public DateTime Created_At { get; set; }

        public Mathistory()
        {
            this.Created_At = DateTime.Now;

            MathistoryFactory theFactory = new MathistoryFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }
    }
}