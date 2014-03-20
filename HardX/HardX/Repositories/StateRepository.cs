using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class StateRepository : HybernoteRepository<HardX.Models.State>
        {
            public StateRepository()
            {
                this._modelName = "State";
            }
        }   
}