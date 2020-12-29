using RoomBookingSystem.BL.DataAccess;
using RoomBookingSystem.BL.DTOs;
using RoomBookingSystem.BL.Extensions;
using RoomBookingSystem.BL.Interfaces;
using RoomBookingSystem.BL.Models;
using RoomBookingSystem.BL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.BL.Services
{
    public class LoginService : ILoginService
    {
        private IConnectionAccessClass connectionAccessClass;

        public LoginService(IConnectionAccessCreator accessCreator)
        {
            this.connectionAccessClass = accessCreator.GetConnectionAccessInstance();
        }

        public LoginModel Authorize(LoginDTO dto)
        {
            var query = $"SELECT * FROM SystemUser WHERE UserLogin = '{dto.Login}'";
            LoginModel loginModel = new LoginModel();

            var dataTable = this.connectionAccessClass.ExecuteQuery(query);

            var userModel = dataTable.ConvertToList<UserDTO>();
            if(userModel.FirstOrDefault() != null)
            {
                if(userModel.First().Password == dto.Password)
                {
                    if(userModel.First().IsRegistered)
                    {
                        loginModel.Login = dto.Login;
                        loginModel.Role = userModel.First().NameOfRole;
                        loginModel.Status = LoginStatuses.Authorized;
                    }
                    else
                    {
                        loginModel.Status = LoginStatuses.NotYetAccepted;
                    }
                }
                else
                {
                    loginModel.Status = LoginStatuses.FailedOnPassword;
                }
            }

            return loginModel;
        }
    }
}
