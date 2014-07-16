using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using System.ComponentModel.DataAnnotations;
using HardX.Factories;
using HardX.Models.Base;
using Iesi.Collections.Generic;

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
            Store theStore = new Store();
            theStore = theStore.GetById(entity.Store.ID);            
            this.Updated_At = DateTime.Now;
            this.Updater = User.CurrentUserId;
            base.Update(entity);
            Devhistory theHistory = new Devhistory(entity);
            theHistory.Save(theHistory);
            
        }

        public virtual ICollection<Devhistory> Devhistories { get; protected set; }

        public Device()
        {
            Devhistories = new HashedSet<Devhistory>();

            DeviceFactory theFactory = new DeviceFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();

        }

        public int GetStoreIDFromHistory(List<Devhistory> theHistory)
        {
            int res = 0;
            var list1 = theHistory.Where(x => x.StoreID == this.Store.ID);
            int list_count1 = list1.Count();
            
            var list2 = list1.Where(x => x.DeviceID == this.ID);
            int list_count2 = list2.Count();

            var list3 = list2.Where(x => x.StatusID == 2);
            int list_count3 = list3.Count();

            if (list_count3 == 0)
            {
                res = -1;
            }
            else
            {
                res = theHistory.Where(x => x.StoreID == this.Store.ID).Where(x => x.DeviceID == this.ID).Where(x => x.StatusID == 2).Last().StoreID;
            }
            return res;
        }

        public string GetStoreName(int StoreID, List<Store> theStore)
        {
            if (StoreID == -1)
            {
                return "не установлен";
            }
            if (theStore.Where(x => x.ID == StoreID).Count() == 1)
            {
                foreach(var item in theStore.Where(x => x.ID == StoreID))
                {
                    return item.Name;
                }
            }
           
            return "e";
        }
    }
}