using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class StateFactory : IFactory<StateRepository>
    {
        public StateRepository createRepository()
        {
            StateRepository theRepository = new StateRepository();
            return theRepository;
        }
    }
}