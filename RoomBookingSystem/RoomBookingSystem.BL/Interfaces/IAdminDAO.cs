using RoomBookingSystem.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.Interfaces
{
    public interface IAdminDAO
    {
        List<UserDTO> GetUnregisteredUsers();

        void DeclineUser(int id);

        void AcceptUser(int id);

        void AcceptBooking(int id);
    }
}
