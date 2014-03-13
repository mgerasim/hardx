using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Core;

namespace HardX.Repositories
{
    public class StoreRepository : HybernoteRepository<HardX.Models.Store>
    {
        public StoreRepository()
        {
            this._modelName = "Store";
        }
    }
}
