using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class MaterialRepository: HybernoteRepository<HardX.Models.Material>
    {
        public MaterialRepository()
        {
            this._modelName = "Material";
        }
    }    
}