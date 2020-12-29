
using RoomBookingSystem.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomBookingSystem.Models
{
    public class SingleBookingModel
    {
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public string Priority { get; set; }

    }
}