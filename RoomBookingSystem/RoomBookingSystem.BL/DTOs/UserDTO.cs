using RoomBookingSystem.BL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.DTOs
{
    public class UserDTO
    {
        [Column("UserId")]
        public int Id { get; set; }

        [Column("UserName")]
        public string Name { get; set; }


        [Column("UserLogin")]
        public string Login { get; set; }

        [Column("UserPassword")]
        public string Password { get; set; }

        [Column("Surname")]
        public string Surname { get; set; }
    
        [Column("UserDescription")]
        public string Description { get; set; }

        public string NameOfRole { get; set; }

        public bool IsRegistered { get; set; }
    }
}
