using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Domain.Repositories;
using NHibernate;
using HardX.Models;
using NHibernate.Criterion;
using Core;
using HardX.Core;

namespace HardX.Repositories
{
    
        public class ActionRepository : HybernoteRepository<HardX.Models.Action>
        {
            public ActionRepository()
            {
                this._modelName = "Action";
            }
        }
    
}