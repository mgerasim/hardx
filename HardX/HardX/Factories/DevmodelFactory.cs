using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Repositories;

namespace HardX.Factories
{
    public class DevmodelFactory : IFactory<DevmodelRepository>
    {
        public DevmodelRepository createRepository()
        {
            DevmodelRepository theDevmodelRepository = new DevmodelRepository();
            return theDevmodelRepository;
        }
    }
}