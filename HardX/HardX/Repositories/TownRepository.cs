using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class TownRepository  : HybernoteRepository<HardX.Models.Town>
        {
            public TownRepository()
            {
                this._modelName = "Town";
            }
        }   
}