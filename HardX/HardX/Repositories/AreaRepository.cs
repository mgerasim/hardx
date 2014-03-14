using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class AreaRepository: HybernoteRepository<HardX.Models.Area>
    {
        public AreaRepository()
        {
            this._modelName = "Area";
        }
    }
}