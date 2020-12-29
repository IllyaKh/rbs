using Autofac;
using Autofac.Integration.Mvc;
using RoomBookingSystem.BL.DataAccess;
using RoomBookingSystem.BL.Interfaces;
using RoomBookingSystem.BL.Services;
using RoomBookingSystem.Controllers;
using RoomBookingSystem.ProxyModels;
using System.Web.Mvc;

namespace RoomBookingSystem
{
    public static class Container
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            DataAccessInfo.SetConnectionString("Server=tcp:rbs.database.windows.net,1433;Database=RoomBookingSystem;User ID=khomenko;Password=25121999Illya;Trusted_Connection=False;Encrypt=True;");


            builder.RegisterType<SqlServerAccessCreator>().As<IConnectionAccessCreator>().WithParameter("connectionString", DataAccessInfo.GetInstance().ConnectionString);

            builder.RegisterType<NotifyController>().As<INotifyReciever>();

            builder.RegisterType<LoginService>().As<ILoginService>();

            builder.RegisterType<RegistrationService>().As<IRegistrationService>();

            builder.RegisterType<BookingScheduleService>().As<IBookingScheduleService>();

            builder.RegisterType<AdminDAO>().As<IAdminDAO>();

            builder.RegisterType<AdminProxy>().As<IAdminProxyDAO>();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}