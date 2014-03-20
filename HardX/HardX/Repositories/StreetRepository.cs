using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class StreetRepository : HybernoteRepository<HardX.Models.Street>
        {
            public StreetRepository()
            {
                this._modelName = "Street";
            }
        }   
}