using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using System.ComponentModel.DataAnnotations;
using HardX.Factories;
using HardX.Models.Base;

namespace HardX.Models
{
    public class Device: DeviceBase
    {
        public override void Save(Device entity)
        {
            this.Created_At = DateTime.Now;
            this.Updated_At = DateTime.Now;
            this.Creater = User.CurrentUserId;
            this.Updater = User.CurrentUserId;
            base.Save(entity);
            Devhistory theHistory = new Devhistory(entity);
            theHistory.Save(theHistory);            
        }

        public override void Update(Device entity)
        {
            this.Updated_At = DateTime.Now;
            this.Updater = User.CurrentUserId;
            base.Update(entity);
            Devhistory theHistory = new Devhistory(entity);
            theHistory.Save(theHistory);           
        }

        public Device()
        {
            DeviceFactory theFactory = new DeviceFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();

        }
    }
}