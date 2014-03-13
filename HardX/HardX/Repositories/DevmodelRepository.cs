using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class DevmodelRepository: HybernoteRepository<HardX.Models.Devmodel>
    {
        public DevmodelRepository()
        {
            this._modelName = "Devmodel";
        }
    }
}