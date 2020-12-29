using RoomBookingSystem.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomBookingSystem.Models
{
    public class UserForAdminModel
    {
        public List<UserDTO> Users { get; set; }
    }
}