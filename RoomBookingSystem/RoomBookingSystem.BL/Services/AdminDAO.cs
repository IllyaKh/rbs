using RoomBookingSystem.BL.DataAccess;
using RoomBookingSystem.BL.DTOs;
using RoomBookingSystem.BL.Extensions;
using RoomBookingSystem.BL.Interfaces;
using System.Collections.Generic;

namespace RoomBookingSystem.BL.Services
{
    public class AdminDAO : IAdminDAO
    {
        private IConnectionAccessClass connectionAccessClass;

        public AdminDAO(IConnectionAccessCreator accessCreator)
        {
            this.connectionAccessClass = accessCreator.GetConnectionAccessInstance();
        }

        public void AcceptBooking(int id)
        {
            var query = $"UPDATE Booking SET BookStatus = 'Accepted' WHERE BookingId = {id}";

            this.connectionAccessClass.ExecuteQuery(query);
        }

        public void AcceptUser(int id)
        {
            var query = $"UPDATE SystemUser SET IsRegistered = 'true' WHERE UserId = {id}";

            this.connectionAccessClass.ExecuteQuery(query);
        }

        public void DeclineUser(int id)
        {
            var query = $"DELETE FROM SystemUser WHERE UserId = {id}";

            this.connectionAccessClass.ExecuteQuery(query);
        }

        public List<UserDTO> GetUnregisteredUsers()
        {
            var query = $"SELECT * FROM SystemUser WHERE IsRegistered = 'false'";

            var dataTable = this.connectionAccessClass.ExecuteQuery(query);

            var usersModel = dataTable.ConvertToList<UserDTO>();

            return usersModel;
        }
    }
}
