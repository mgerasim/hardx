using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Repositories;

namespace HardX.Factories
{
    public class RoleFactory:IFactory<RoleRepository>
    {
        public RoleRepository createRepository()
        {
            RoleRepository theRoleRepository = new RoleRepository();
            return theRoleRepository;
        }
    }
}