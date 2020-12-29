using RoomBookingSystem.BL.DataAccess;
using RoomBookingSystem.BL.DTOs;
using RoomBookingSystem.BL.Extensions;
using RoomBookingSystem.BL.Interfaces;
using RoomBookingSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.Services
{
    public class BookingScheduleService : IBookingScheduleService
    {
        private IConnectionAccessClass connectionAccessClass;

        public BookingScheduleService(IConnectionAccessCreator accessCreator)
        {
            this.connectionAccessClass = accessCreator.GetConnectionAccessInstance();
        }

        public List<BookingDTO> GetDailyBookings()
        {
            var query = $"SELECT * FROM Booking JOIN SystemUser ON(Booking.UserId = SystemUser.UserId) JOIN Room ON(Booking.RoomId = Room.RoomId) WHERE CONVERT(DATE, Booking.StartDate) = '{DateTime.Now.Date.ToString("yyyy-MM-dd")}'";

            var dataTable = this.connectionAccessClass.ExecuteQuery(query);

            var bookingList = dataTable.ConvertToList<BookingDTO>();

            return bookingList;
        }

        public List<BookingDTO> GetYearlyBookings()
        {
            var query = $"SELECT * FROM Booking JOIN SystemUser ON(Booking.UserId = SystemUser.UserId) JOIN Room ON(Booking.RoomId = Room.RoomId) WHERE YEAR(CONVERT(DATE, Booking.StartDate)) = YEAR('{DateTime.Now.Date.ToString("yyyy-MM-dd")}')";

            var dataTable = this.connectionAccessClass.ExecuteQuery(query);

            var bookingList = dataTable.ConvertToList<BookingDTO>();


            return bookingList;

        }

        public List<BookingDTO> GetMonthlyBookings()
        {
            var query = $"SELECT * FROM Booking JOIN SystemUser ON(Booking.UserId = SystemUser.UserId) JOIN Room ON(Booking.RoomId = Room.RoomId) WHERE MONTH(CONVERT(DATE, Booking.StartDate)) = MONTH('{DateTime.Now.Date.ToString("yyyy-MM-dd")}') AND YEAR(CONVERT(DATE, Booking.StartDate)) = YEAR('{DateTime.Now.Date.ToString("yyyy-MM-dd")}')";

            var dataTable = this.connectionAccessClass.ExecuteQuery(query);

            var bookingList = dataTable.ConvertToList<BookingDTO>();

            return bookingList;
        }


        public void RemoveBooking(int id)
        {
            var query = $"DELETE FROM BOOKING WHERE BookingId = {id}";

            this.connectionAccessClass.ExecuteQuery(query);
        }


        public BookingDTO EditBooking(int id)
        {
            var query = $"SELECT * FROM Booking WHERE BookingId = {id}";

            var dataTable = this.connectionAccessClass.ExecuteQuery(query);

            var booking = dataTable.ConvertToList<BookingDTO>();

            return booking.FirstOrDefault();
        }

        public void UpdateBooking(BookingDTO dto, int id)
        {
            var query = $"UPDATE Booking SET StartDate ='{dto.Start.ToString("yyyy-MM-dd HH:mm:ss.fff")}', EndDate ='{dto.End.ToString("yyyy-MM-dd HH:mm:ss.fff")}', Priority = '{dto.Priority}' WHERE BookingId = {id}";

            this.connectionAccessClass.ExecuteQuery(query);
        }

        public void CreateBooking(BookingDTO dto)
        {
            var selectUserquery = $"SELECT UserId FROM SystemUser WHERE UserLogin = '{dto.User}'";

            var datatable = this.connectionAccessClass.ExecuteQuery(selectUserquery);
            var user = datatable.ConvertToList<UserDTO>().First();

            var selectBookQuery = $"SELECT RoomId FROM Room WHERE RoomNumber = '{dto.Room}'";
            var roomDataTable = this.connectionAccessClass.ExecuteQuery(selectBookQuery);
            var room = roomDataTable.ConvertToList<RoomDTO>().First();

            var query = $"INSERT INTO Booking (StartDate, EndDate, Priority, IsInternal, UserId, RoomId) VALUES ('{dto.Start.ToString("yyyy-MM-dd HH:mm:ss.fff")}','{dto.End.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{dto.Priority}', '{dto.IsInternal}', '{user.Id}', '{room.RoomId}')";

            this.connectionAccessClass.ExecuteQuery(query);
        }


        public List<RoomEquipDTO> GetRooms()
        {
            var selectQuery = $"SELECT Room.RoomId, Room.RoomNumber, Room.RoomSize, Equipment.EquipmentName FROM Room INNER JOIN EquipmentRoom ON Room.RoomId = EquipmentRoom.RoomId INNER JOIN Equipment ON EquipmentRoom.EquipmentId = Equipment.EquipmentId";

            var datatable = this.connectionAccessClass.ExecuteQuery(selectQuery);
            var rommEquip = datatable.ConvertToList<RoomDTO>();

            List<RoomEquipDTO> roomEquipDTO = new List<RoomEquipDTO>();

            foreach(var romm in rommEquip)
            {
                var r = roomEquipDTO.FirstOrDefault(x => x.RoomNumber == romm.RoomNumber);
                if (r == null)
                {
                    roomEquipDTO.Add(new RoomEquipDTO() { RoomId = romm.RoomId, RoomNumber = romm.RoomNumber, RoomSize = romm.RoomSize, EquipmentName = new List<string>() { romm.EquipmentName } });
                }
                else
                {
                    roomEquipDTO.FirstOrDefault(x => x.RoomNumber == romm.RoomNumber).EquipmentName.Add(romm.EquipmentName);
                }
            }

            return roomEquipDTO;

        }

        public List<BookingPopularityDTO> GetPopularity()
        {
            var query = $"SELECT COUNT(*) AS mycount, Room.RoomNumber FROM Booking JOIN Room ON Booking.RoomId = Room.RoomId GROUP BY Room.RoomNumber ORDER BY mycount DESC";

            var table = this.connectionAccessClass.ExecuteQuery(query);

            var pop = table.ConvertToList<BookingPopularityDTO>();

            return pop;
        }

        public void PushNotify(string message)
        {
            throw new NotImplementedException();
        }
    }
}
