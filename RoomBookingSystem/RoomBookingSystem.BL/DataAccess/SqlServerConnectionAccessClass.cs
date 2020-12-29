using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.DataAccess
{
    public class SqlServerConnectionAccessClass : IConnectionAccessClass
    {
        public SqlServerConnectionAccessClass(string connectionString)
        {

        }

        public DataTable ExecuteQuery(string query)
        {
            SqlConnection connection = new SqlConnection(DataAccessInfo.GetInstance().ConnectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");

                SqlCommand command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                var resultTable = new DataTable();
                resultTable.Load(reader);

                return resultTable;
            }
            catch (SqlException ex)
            {
                throw new Exception("Connection to database failed.");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }
        }

    }
}
