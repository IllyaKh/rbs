using System.Data;

namespace RoomBookingSystem.BL.DataAccess
{
    public interface IConnectionAccessClass
    {
        DataTable ExecuteQuery(string query);
    }
}