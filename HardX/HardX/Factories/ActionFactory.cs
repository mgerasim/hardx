using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Repositories;

namespace HardX.Factories
{
    public class ActionFactory:IFactory<ActionRepository>
    {
        public ActionRepository createRepository()
        {
            ActionRepository theActionRepository = new ActionRepository();
            return theActionRepository;
        }
    }
}