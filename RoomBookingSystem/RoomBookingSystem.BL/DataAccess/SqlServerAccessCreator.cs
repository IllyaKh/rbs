using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.DataAccess
{
    public class SqlServerAccessCreator : ConnectionAccessCreator
    {
        private string connectionString;

        public SqlServerAccessCreator(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override IConnectionAccessClass GetConnectionAccessInstance()
        {
            DataAccessInfo.SetConnectionString(this.connectionString);
            var connectionAccess = DataAccessInfo.GetInstance();

            return new SqlServerConnectionAccessClass(connectionAccess.ConnectionString);
        }
    }
}
