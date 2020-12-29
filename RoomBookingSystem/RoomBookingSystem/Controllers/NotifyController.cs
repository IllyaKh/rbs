using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomBookingSystem.Controllers
{
    public class NotifyController : Controller, INotifyReciever
    {
        // GET: Notify
        public ActionResult Index(string message)
        {
            return View();
        }

        public ActionResult NotifyPage(string message)
        {
            return View(message);
        }

        public void PushNotify(string message)
        {
            this.NotifyPage(message);
        }
    }
}