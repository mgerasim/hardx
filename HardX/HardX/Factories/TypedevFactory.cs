using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class TypedevFactory : IFactory<TypedevRepository>
    {
        public TypedevRepository createRepository()
        {
            TypedevRepository theTypedevRepository = new TypedevRepository();
            return theTypedevRepository;
        }
    }
}