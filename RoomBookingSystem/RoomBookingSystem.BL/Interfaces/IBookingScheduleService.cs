using RoomBookingSystem.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.Interfaces
{
    public interface IBookingScheduleService
    {
        List<BookingDTO> GetDailyBookings();

        List<BookingDTO> GetYearlyBookings();

        List<BookingDTO> GetMonthlyBookings();

        void RemoveBooking(int id);

        BookingDTO EditBooking(int id);

        void UpdateBooking(BookingDTO dto, int id);

        void CreateBooking(BookingDTO dto);

        List<RoomEquipDTO> GetRooms();

        List<BookingPopularityDTO> GetPopularity();
    }
}
