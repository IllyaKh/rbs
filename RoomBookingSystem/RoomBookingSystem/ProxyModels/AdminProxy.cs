using RoomBookingSystem.BL.DTOs;
using RoomBookingSystem.BL.Interfaces;
using RoomBookingSystem.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomBookingSystem.ProxyModels
{
    public class AdminProxy : IAdminProxyDAO
    {
        private IAdminDAO adminDAO;

        public AdminProxy(IAdminDAO adminDAO)
        {
            this.adminDAO = adminDAO;
        }

        public void AcceptBooking(int id, string role)
        {
            if (role == "Admin")
            {
                adminDAO.AcceptBooking(id);
            }
        }

        public void AcceptUser(int id, string role)
        {
            if(role == "Admin")
            {
                adminDAO.AcceptUser(id);
            }
        }

        public void DeclineUser(int id, string role)
        {
            if(role == "Admin")
            {
                adminDAO.DeclineUser(id);
            }
        }

        public List<UserDTO> GetUnregisteredUsers(string role)
        {
            if(role == "Admin")
            {
               return adminDAO.GetUnregisteredUsers();
            }

            return null;
        }
    }
}