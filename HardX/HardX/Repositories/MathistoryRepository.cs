using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class MathistoryRepository : HybernoteRepository<HardX.Models.Mathistory>
    {
        public MathistoryRepository()
        {
            this._modelName = "Mathistory";
        }
    }    
}