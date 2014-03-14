using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class MaterialUchetRepository: HybernoteRepository<HardX.Models.MaterialUchet>
    {
        public MaterialUchetRepository()
        {
            this._modelName = "MaterialUchet";
        }
    }    
}