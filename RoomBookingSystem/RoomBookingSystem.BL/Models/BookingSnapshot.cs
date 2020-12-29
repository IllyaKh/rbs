using RoomBookingSystem.BL.DTOs;
using System;

namespace RoomBookingSystem.Models
{
    public class BookingSnapshot
    {
        public BookingDTO Booking { get; set; }

        public int Id { get; set; }

        public string User { get; set; }

        public string Room { get; set; }


        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool IsInternal { get; set; }

        public string Priority { get; set; }

        public string BookStatus { get; set; }

        public void Restore()
        {
            this.Booking.Id = this.Id;
            this.Booking.IsInternal = this.IsInternal;
            this.Booking.Priority = this.Priority;
            this.Booking.Room = this.Room;
            this.Booking.Start = this.Start;
            this.Booking.User = this.User;
            this.Booking.End = this.End;
            this.Booking.BookStatus = this.BookStatus;
        }
    }
}