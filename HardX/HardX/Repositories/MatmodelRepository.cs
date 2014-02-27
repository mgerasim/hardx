using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class MatmodelRepository : HybernoteRepository<HardX.Models.Matmodel>
    {
        public MatmodelRepository()
        {
            this._modelName = "Matmodel";
        }
    }
}