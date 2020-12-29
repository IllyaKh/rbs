using RoomBookingSystem.BL.DTOs;
using System.Collections.Generic;

namespace RoomBookingSystem.BL.Interfaces
{
    public interface IAdminProxyDAO
    {
        List<UserDTO> GetUnregisteredUsers(string role);

        void DeclineUser(int id, string role);

        void AcceptUser(int id, string role);

        void AcceptBooking(int id, string role);
    }
}
