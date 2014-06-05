using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class StoreDevDetailRepository : HybernoteRepository<HardX.Models.StoreDevDetail>
    {
        public StoreDevDetailRepository()
        {
            this._modelName = "StoreDevDetail";
        }
    }
}