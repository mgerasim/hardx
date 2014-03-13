using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class TypedevRepository : HybernoteRepository<HardX.Models.Typedev>
    {
        public TypedevRepository()
        {
            this._modelName = "Typedev";
        }
    }
}