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

       

        public Store()
        {
            StoreFactory theStoreFactory = new StoreFactory();
            _repository = theStoreFactory.createRepository();
            if (_repository == null)
                throw new NotImplementedException();

            this._Materials = new Iesi.Collections.Generic.HashedSet<Material>();
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