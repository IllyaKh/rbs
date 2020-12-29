using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomBookingSystem.Models
{
    public class BookCreationModel
    {
        public string User { get; set; }

        public string Room { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool IsInternal { get; set; }

        public string Priority { get; set; }
    }
}