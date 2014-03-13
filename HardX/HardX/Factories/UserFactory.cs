using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Repositories;

namespace HardX.Factories
{
    public class UserFactory:IFactory<UserRepository>
    {

        public UserRepository createRepository()
        {
            UserRepository theUserRepository = new UserRepository();
            return theUserRepository;
        }
    }
}