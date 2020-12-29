using RoomBookingSystem.BL.DataAccess;
using RoomBookingSystem.BL.DTOs;
using RoomBookingSystem.BL.Interfaces;
using RoomBookingSystem.BL.Models.Enums;
using RoomBookingSystem.Models;
using System.Web.Mvc;

namespace RoomBookingSystem.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService loginService;
        private IRegistrationService regService;

        public LoginController(ILoginService loginService, IRegistrationService regService)
        {
            this.loginService = loginService;
            this.regService = regService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var loginModel = new LoginDTO() { Login = model.Login, Password = model.Password };
            var authorizedModel = this.loginService.Authorize(loginModel);

            if(authorizedModel.Status == LoginStatuses.NotYetAccepted)
            {
                return RedirectToAction("NotYetAuthorized");
            }
            else if(authorizedModel.Status == LoginStatuses.Authorized)
            {
                Session["User"] = authorizedModel.Login;
                Session["Role"] = authorizedModel.Role;
                return RedirectToAction("ShowTodayBookings", "Main");
            }

            return View(model);
        }

        // GET: Login
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            regService.Registrate(new RegisterDTO() { Login = model.Login, Name = model.Name, Password = model.Password });
            return RedirectToAction("WaitForAdminRequest");
        }

        public ActionResult NotYetAuthorized()
        {
            return View();
        }

        public ActionResult WaitForAdminRequest()
        {
            return View();
        }
    }
}