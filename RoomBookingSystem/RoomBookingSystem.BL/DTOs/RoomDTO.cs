using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.DTOs
{
    public class RoomDTO
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; }

        public string RoomSize { get; set; }

        public string EquipmentName { get; set; }
    }
}
