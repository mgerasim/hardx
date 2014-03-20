using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;
using HardX.Repositories;

namespace HardX.Factories
{
    public class RoomFactory : IFactory<RoomRepository>
    {
        public RoomRepository createRepository()
        {
            RoomRepository theRepository = new RoomRepository();
            return theRepository;
        }
    }
}