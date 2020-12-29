using RoomBookingSystem.BL.DTOs;
using RoomBookingSystem.BL.Models;

namespace RoomBookingSystem.BL.Interfaces
{
    public interface ILoginService
    {
        LoginModel Authorize(LoginDTO dto);
    }
}
