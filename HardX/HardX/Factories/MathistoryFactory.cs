using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Repositories;
using HardX.Core;

namespace HardX.Factories
{
    public class MathistoryFactory : IFactory<MathistoryRepository>
    {
        public MathistoryRepository createRepository()
        {
            MathistoryRepository theRepository = new MathistoryRepository();
            return theRepository;
        }
    }
}