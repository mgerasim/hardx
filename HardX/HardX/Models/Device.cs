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
            // Проверяем есть ли дня нового склада - позиция добавляемых моделей оборудования (S0026)
            if (entity.Store.StoreDevDetails.Count(x => x.Devmodel.ID == entity.Devmodel.ID) == 0)
            {
                StoreDevDetail detail = new StoreDevDetail();
                detail.Devmodel = (new Devmodel()).GetById(entity.Devmodel.ID);
                detail.Store = (new Store()).GetById(entity.Store.ID);
                detail.Save(detail);
            }
        }

        public override void Update(Device entity)
        {
            Store theStore = new Store();
            theStore = theStore.GetById(entity.Store.ID);
            // Проверяем есть ли дня нового склада - позиция добавляемых моделей оборудования (S0026)
            if (theStore.StoreDevDetails.Count(x => x.Devmodel.ID == entity.Devmodel.ID) == 0)
            {
                StoreDevDetail detail = new StoreDevDetail();
                detail.Devmodel = (new Devmodel()).GetById(entity.Devmodel.ID);
                detail.Store = theStore;
                detail.Save(detail);
            }
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