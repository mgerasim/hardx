using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class StoreMatDetailRepository : HybernoteRepository<HardX.Models.StoreMatDetail>
    {
        public StoreMatDetailRepository()
        {
            this._modelName = "StoreMatDetail";
        }
    }
}