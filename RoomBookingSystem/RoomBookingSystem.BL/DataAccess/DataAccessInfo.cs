using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.DataAccess
{
    public class DataAccessInfo
    {
        private static DataAccessInfo instance;

        private DataAccessInfo() { }

        public string ConnectionString { get; private set; }

        public static DataAccessInfo GetInstance()
        {
            if (instance == null)
            {
                instance = new DataAccessInfo();
            }

            return instance;
        }

        public static void SetConnectionString(string connectionString)
        {
            if (instance == null)
            {
                instance = new DataAccessInfo();
            }

            instance.ConnectionString = connectionString;
        }
    }
}
