using RoomBookingSystem.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomBookingSystem.Models
{
    public class PopularModel
    {
        public List<BookingPopularityDTO> Popularity { get; set; }
    }
}