using System.Web.Mvc;

namespace RoomBookingSystem.Controllers
{
    public interface INotifyReciever
    {
        void PushNotify(string message);
    }
}