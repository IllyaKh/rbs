using RoomBookingSystem.BL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.DTOs
{
    public class BookingPopularityDTO
    {
        [Column("mycount")]
        public int Number { get; set; }

        [Column("RoomNumber")]
        public string Room { get; set; }
    }
}
