using RoomBookingSystem.BL.Extensions;
using RoomBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.DTOs
{
    public class BookingDTO
    {
        [Column("BookingId")]
        public int Id { get; set; }

        [Column("UserLogin")]
        public string User { get; set; }

        [Column("RoomNumber")]
        public string Room { get; set; }

        [Column("StartDate")]

        public DateTime Start { get; set; }

        [Column("EndDate")]
        public DateTime End { get; set; }

        public bool IsInternal { get; set; }

        public string Priority { get; set; }

        public string BookStatus { get; set; }

        public BookingDTO()
        {

        }
        public BookingSnapshot CreateSnapshot()
        {
            return new BookingSnapshot() { Id = this.Id, BookStatus = this.BookStatus, End = this.End, IsInternal = this.IsInternal, Priority = this.Priority, Room = this.Room, Start = this.Start, User = this.User, Booking = this };
        }

        public BookingDTO(Builder builder)
        {
            if(builder.id!=0)
            this.Id = builder.id;
            this.User = builder.user;
            this.Room = builder.room;
            this.Start = builder.start;
            this.End = builder.end;
            this.Priority = builder.priority;
            if(builder.bookStatus!=null)
            this.BookStatus = builder.bookStatus;
            this.IsInternal = builder.isInternal;
        }

        public class Builder
        {
            public int id { get; set; }
            public string user { get; }
            public string room { get; }
            public DateTime start { get; }
            public DateTime end { get; }
            public bool isInternal { get; set; }
            public string priority { get; }
            public string bookStatus { get; set; }

            public Builder(string user, string room, DateTime start, DateTime end, string priority)
            {
                this.user = user;
                this.room = room;
                this.start = start;
                this.end = end;
                this.priority = priority;
                this.isInternal = false;
            }

            public Builder IsInternal(bool isInternal)
            {
                this.isInternal = isInternal;
                return this;
            }

            public Builder Id(int id)
            {
                this.id = id;
                return this;
            }

            public Builder BookStatus(string bookStatus)
            {
                this.bookStatus = bookStatus;
                return this;
            }

            public BookingDTO Build()
            {
                return new BookingDTO(this);
            }

        }
    }
}
