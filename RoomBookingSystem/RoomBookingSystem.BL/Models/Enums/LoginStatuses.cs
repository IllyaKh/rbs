using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.Models.Enums
{
    public enum LoginStatuses
    {
        FailedOnLogin = 0,
        
        FailedOnPassword = 1,

        Authorized = 2, 

        NotYetAccepted = 3
    }
}
