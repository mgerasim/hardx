using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class RegionRepository : HybernoteRepository<HardX.Models.Region>
        {
            public RegionRepository()
            {
                this._modelName = "Region";
            }
        }   
}