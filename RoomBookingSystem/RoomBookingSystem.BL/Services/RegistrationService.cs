using RoomBookingSystem.BL.DataAccess;
using RoomBookingSystem.BL.DTOs;
using RoomBookingSystem.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.Services
{
    public class RegistrationService : IRegistrationService
    {

        private IConnectionAccessClass connectionAccessClass;

        public RegistrationService(IConnectionAccessCreator accessCreator)
        {
            this.connectionAccessClass = accessCreator.GetConnectionAccessInstance();
        }

        public void Registrate(RegisterDTO dto)
        {
            string query = $"INSERT INTO SystemUser (UserLogin, UserName, UserPassword, NameOfRole, IsRegistered ) VALUES ('{dto.Login}','{dto.Name}', '{dto.Password}', 'User', 'false')";

            this.connectionAccessClass.ExecuteQuery(query);
        }
    }
}
