using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Core;
using HardX.Factories;
using HardX.Models.Base;

namespace HardX.Models
{
    public class Material : MaterialBase
    {
        
        public override void Save(Material entity)
        {
            this.Created_At = DateTime.Now;
            this.Updated_At = DateTime.Now;
            this.Creater = User.CurrentUserId;
            this.Updater = User.CurrentUserId;
            base.Save(entity);
            Mathistory theHistory = new Mathistory(entity);
            theHistory.Save(theHistory);            
        }

        public override void Update(Material entity)
        {
            this.Updated_At = DateTime.Now;
            this.Updater = User.CurrentUserId;
            Mathistory theHistory = new Mathistory(entity);            
            base.Update(entity);            
            theHistory.Save(theHistory);           
        }


        public Material()
        {
            this.Created_At = DateTime.Now;
            this.Updated_At = DateTime.Now;
            this.StatusID = 1;
            MaterialFactory theFactory = new MaterialFactory();
            _repository = theFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();
        }

        public Material(Material model)
            : this()
        {
            this.Matmodel = (new Matmodel()).GetById(model.Matmodel.ID);
            this.Store = (new Store()).GetById(model.Store.ID);
            this.fAdded = model.fAdded;
            this.DeviceID = model.DeviceID;
        }
    }
}