using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class HouseRepository : HybernoteRepository<HardX.Models.House>
        {
            public HouseRepository()
            {
                this._modelName = "House";
            }
        }   
}