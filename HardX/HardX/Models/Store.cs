using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HardX.Core;
using HardX.Factories;
using System.Web.Mvc;

namespace HardX.Models
{
    public class Store : Entity<Store>
    {
        private int _Id;
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "* Укажите наименование доступа")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* длина наименования должна быть не менее чем 2 и не более чем 50 символов")]
        [Editable(true)]
        private string _Name;

        private Iesi.Collections.Generic.ISet<Material> _Materials;

        public virtual Iesi.Collections.Generic.ISet<Material> Materials
        {
            get
            {
                return this._Materials;
            }
            set
            {
                this._Materials = value;
            }
        }

        private Iesi.Collections.Generic.ISet<Device> _Devices;

        public virtual Iesi.Collections.Generic.ISet<Device> Devices
        {
            get
            {
                return this._Devices;
            }
            set
            {
                this._Devices = value;
            }
        }


        private Iesi.Collections.Generic.ISet<Area> _Areas;

        public virtual Iesi.Collections.Generic.ISet<Area> Areas
        {
            get
            {
                return this._Areas;
            }
            set
            {
                this._Areas = value;
            }
        }

        private Iesi.Collections.Generic.ISet<StoreDevDetail> _StoreDevDetails;

        public virtual Iesi.Collections.Generic.ISet<StoreDevDetail> StoreDevDetails
        {
            get
            {
                return this._StoreDevDetails;
            }
            set
            {
                this._StoreDevDetails = value;
            }
        }

        private Iesi.Collections.Generic.ISet<StoreMatDetail> _StoreMatDetails;

        public virtual Iesi.Collections.Generic.ISet<StoreMatDetail> StoreMatDetails
        {
            get
            {
                return this._StoreMatDetails;
            }
            set
            {
                this._StoreMatDetails = value;
            }
        }

       

        public Store()
        {
            StoreFactory theStoreFactory = new StoreFactory();
            _repository = theStoreFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();

            this._Materials = new Iesi.Collections.Generic.HashedSet<Material>();
            this._Devices = new Iesi.Collections.Generic.HashedSet<Device>();

            this._Areas = new Iesi.Collections.Generic.HashedSet<Area>();

            this._StoreDevDetails = new Iesi.Collections.Generic.HashedSet<StoreDevDetail>();
            this._StoreMatDetails = new Iesi.Collections.Generic.HashedSet<StoreMatDetail>();
        }

        public virtual string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        public virtual int ID
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }

        [Display(Name = "Кладовщик")]
        [Required(ErrorMessage = "* Укажите кладовщика №1")]
        public virtual User User { get; set; }

        [Display(Name = "Кладовщик 2")]
        [Required(ErrorMessage = "* Укажите кладовщика №2")]
        public virtual User User2 { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "* Укажите адрес")]
        public virtual Room Room { get; set; }

        public virtual void ClearAreas()
        {
            this._Areas.Clear();
        }

        public virtual Boolean IsExistArea(int areaID)
        {
            foreach (var theArea in this.Areas)
            {
                if (theArea.Id == areaID)
                {
                    return true;
                }
            }
            return false;
        }

        public virtual int GetDeviceCount(int DevmodelID, int StatusID)
        {
            int res = 0;
            foreach (var item in Devices)
            {
                if (item.Devmodel.ID == DevmodelID && item.StatusID == StatusID)
                {
                    res++;
                }
            }

            return res;
        }

        public virtual int GetMaterialCount(int MatmodelID, int StatusID)
        {
            int res = 0;
            foreach (var item in Materials)
            {
                if (item.Matmodel.ID == MatmodelID && item.StatusID == StatusID)
                {
                    res++;
                }
            }

            return res;
        }

        public virtual int GetMaterialCountFromList(List<Material> theList, int MatmodelID, int StatusID)
        {
            int res = 0;
            foreach (var item in theList)
            {
                if (item.Matmodel.ID == MatmodelID && item.StatusID == StatusID)
                {
                    res++;
                }
            }
            return res;
        }

        public virtual int GetDeviceCountFromList(List<Device> theList, int DevmodelID, int StatusID)
        {
            int res = 0;
            foreach (var item in theList)
            {
                if (item.Devmodel.ID == DevmodelID && item.StatusID == StatusID)
                {
                    res++;
                }
            }
            return res;
        }

        public virtual int GetMaterialsCountFromHistory(List<Mathistory> theHistory, int MatmodelID, int StatusID)
        {
            int res = 0;
            
                res = theHistory.Where(x => x.StatusID == StatusID)
                    .Where(x => x.MatmodelID == MatmodelID)
                    .Where(x => x.StoreID == this.ID)
                    .Count();
            return res;
        }

        public virtual int GetDevicesCountFromHistory(List<Devhistory> theHistory, int DevmodelID, int StatusID)
        {
            int res = 0;
            
                res = theHistory.Where(x => x.StatusID == StatusID)
                    .Where(x => x.DevmodelID == DevmodelID)
                    .Where(x => x.StoreID == this.ID)
                    .Count();
            
            return res;
        }
    }


    public class NewStore : Store
    {
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "* Укажите наименование склада")]
        [Remote("IsStoreName_Available", "StoreValidation")]
        [Editable(true)]
        public override string Name { get; set; }
    }
}