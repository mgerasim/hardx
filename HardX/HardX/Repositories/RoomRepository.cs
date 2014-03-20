using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Core;

namespace HardX.Repositories
{
    public class RoomRepository : HybernoteRepository<HardX.Models.Room>
        {
            public RoomRepository()
            {
                this._modelName = "Room";
            }
        }   
}