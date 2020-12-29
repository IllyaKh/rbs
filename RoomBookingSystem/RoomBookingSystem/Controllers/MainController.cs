using RoomBookingSystem.BL.DTOs;
using RoomBookingSystem.BL.Interfaces;
using RoomBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomBookingSystem.Controllers
{
    public class MainController : Controller, INotifyPusher
    {
        public static BookingsModel currentShowingBooking;

        public static BookingSnapshots snapshots = new BookingSnapshots();

        IBookingScheduleService scheduleService;

        IAdminProxyDAO adminService;

        private List<INotifyReciever> observers = new List<INotifyReciever>();

        public MainController(IBookingScheduleService scheduleService, IAdminProxyDAO adminService, INotifyReciever reciever)
        {
            this.scheduleService = scheduleService;
            this.adminService = adminService;
            this.AttachNotifier(reciever);
        }

        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowTodayBookings()
        {
            currentShowingBooking = new BookingsModel() { Bookings = this.scheduleService.GetDailyBookings() };

            if (snapshots.Snapshots == null)
            {
                snapshots.Snapshots = currentShowingBooking.Bookings.Select(x => new BookingSnapshot() { Id = x.Id, BookStatus = x.BookStatus, End = x.End, IsInternal = x.IsInternal, Priority = x.Priority, Room = x.Room, Start = x.Start, User = x.User, Booking = x }).ToList();
            }

            return View(currentShowingBooking);
        }

        public ActionResult YearBooking()
        {
            currentShowingBooking = new BookingsModel() { Bookings = this.scheduleService.GetYearlyBookings() };

            if(snapshots.Snapshots == null)
            {
                snapshots.Snapshots = currentShowingBooking.Bookings.Select(x => new BookingSnapshot() { Id = x.Id, BookStatus = x.BookStatus, End = x.End, IsInternal = x.IsInternal, Priority = x.Priority, Room = x.Room, Start = x.Start, User = x.User, Booking = x }).ToList();
            }

            return View(currentShowingBooking);
        }

        public ActionResult MonthBooking()
        {
            currentShowingBooking = new BookingsModel() { Bookings = this.scheduleService.GetMonthlyBookings() };

            if (snapshots.Snapshots == null)
            {
                snapshots.Snapshots = currentShowingBooking.Bookings.Select(x => new BookingSnapshot() { Id = x.Id, BookStatus = x.BookStatus, End = x.End, IsInternal = x.IsInternal, Priority = x.Priority, Room = x.Room, Start = x.Start, User = x.User, Booking = x }).ToList();
            }

            return View(currentShowingBooking);
        }

        public ActionResult DeleteBooking(int id)
        {
            scheduleService.RemoveBooking(id);

            return RedirectToAction("ShowTodayBookings");
        }

        public ActionResult EditBookingConcrete(int id)
        {
            var bookingDTO = this.scheduleService.EditBooking(id);

            var modeler = new SingleBookingModel() { StartDate = bookingDTO.Start, EndDate = bookingDTO.End, Priority = bookingDTO.Priority };

            return View(modeler);
        }

        [HttpPost]
        public ActionResult EditBookingConcrete(SingleBookingModel dmodel, int id)
        {
            var model = new BookingDTO() { Start = dmodel.StartDate, End = dmodel.EndDate, Priority = dmodel.Priority };
            
            for(int i = 0; i < snapshots.Snapshots.Count; i++)
            {
                if(snapshots.Snapshots[i].Id == id)
                {
                    snapshots.Snapshots[i] = currentShowingBooking.Bookings.FirstOrDefault(x => x.Id == id).CreateSnapshot();
                }
            }

            this.scheduleService.UpdateBooking(model, id);

            var snapshot = snapshots.Snapshots.FirstOrDefault(x => x.Id == id);

            return RedirectToAction("ShowTodayBookings");
        }

        [HttpGet]
        public ActionResult CreateBooking()
        {
            var rooms = scheduleService.GetRooms();

            var roomsModel = new RoomsModel() { Rooms = rooms };

            return View(roomsModel);
        }


        [HttpPost]
        public ActionResult CreateBooking(BookCreationModel creationModel)
        {
            var model = new BookingDTO.Builder(Session["User"].ToString(), creationModel.Room, creationModel.Start, creationModel.End, creationModel.Priority).IsInternal(creationModel.IsInternal).Build();

            try
            {
                this.scheduleService.CreateBooking(model);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            this.Notify("Booking successfully created");

            return View("~/Views/Notify/NotifyPage.cshtml", new { message = "Booking successfully created"});

        }


        public ActionResult AdminApprover()
        {
            UserForAdminModel model = new UserForAdminModel() { Users = adminService.GetUnregisteredUsers(Session["Role"]?.ToString()) };

            return View(model);
        }

        public ActionResult DeclineUser(int id)
        {
            this.adminService.DeclineUser(id, Session["Role"]?.ToString());

            return RedirectToAction("AdminApprover");
        }

        public ActionResult AcceptUser(int id)
        {
            this.adminService.AcceptUser(id, Session["Role"]?.ToString());

            return RedirectToAction("AdminApprover");
        }


        public ActionResult AcceptBooking(int id)
        {
            this.adminService.AcceptBooking(id, Session["Role"]?.ToString());

            return RedirectToAction("AdminApprover");
        }

        public ActionResult Popular()
        {
            PopularModel model = new PopularModel() { Popularity = this.scheduleService.GetPopularity() };

            return View(model);
        }

        public ActionResult RevertBooking(int id)
        {
            var snapshot = snapshots.Snapshots.FirstOrDefault(x => x.Id == id);
            if (snapshot != null)
            {
                snapshot.Restore();
            }

            this.scheduleService.UpdateBooking(snapshot.Booking, id);

            return RedirectToAction("ShowTodayBookings");
        }

        public void AttachNotifier(INotifyReciever reciever)
        {
            this.observers.Add(reciever);
        }

        public void Notify(string message)
        {
            foreach(var o in this.observers)
            {
                o.PushNotify(message);
            }
        }
    }
}