using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.DTOs
{
    public class RoomEquipDTO
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; }

        public string RoomSize { get; set; }

        public List<string> EquipmentName { get; set; }

    }
}
