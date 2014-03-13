using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using Core.Domain.Repositories;
using NHibernate;
using HardX.Models;
using NHibernate.Criterion;
using HardX.Core;

namespace HardX.Repositories
{
        public class BrancheRepository : HybernoteRepository<HardX.Models.Branche>
        {
            public BrancheRepository()
            {
                this._modelName = "Branche";
            }
        }   
}