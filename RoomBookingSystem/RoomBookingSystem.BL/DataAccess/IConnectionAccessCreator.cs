namespace RoomBookingSystem.BL.DataAccess
{
    public interface IConnectionAccessCreator
    {
        IConnectionAccessClass GetConnectionAccessInstance();
    }
}