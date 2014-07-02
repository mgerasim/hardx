using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class DevhistoryRepository : HybernoteRepository<HardX.Models.Devhistory>
    {
        public DevhistoryRepository()
        {
            this._modelName = "Devhistory";
        }
    }    
}