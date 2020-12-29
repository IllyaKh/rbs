using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.DataAccess
{
    public abstract class ConnectionAccessCreator : IConnectionAccessCreator
    {
        protected string ConnectionString { get; set; }

        public abstract IConnectionAccessClass GetConnectionAccessInstance();
    }
}
