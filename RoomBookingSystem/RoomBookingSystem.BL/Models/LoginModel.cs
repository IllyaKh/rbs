using RoomBookingSystem.BL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.Models
{
    public class LoginModel
    {
        public string Login { get; set; }

        public string Role { get; set; }

        public LoginStatuses Status { get; set; }
    }
}
