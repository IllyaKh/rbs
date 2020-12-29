namespace RoomBookingSystem.Controllers
{
    internal interface INotifyPusher
    {
        void AttachNotifier(INotifyReciever reciever);

        void Notify(string message);
    }
}