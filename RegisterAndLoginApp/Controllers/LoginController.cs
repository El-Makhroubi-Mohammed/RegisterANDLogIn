using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using RegisterAndLoginApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {

        // private static Logger logger = LogManager.GetLogger("RegisterLoginAppRule");

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CustomAuthorization]
        public IActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("I am a protected method if the proper attribute is applied to me.");
        }

        [LogActionFilter]
        public IActionResult ProcessLogin(UserModel userModel)
        {
            // MyLogger.GetInstance().Info("Processing a login attempt");
            // MyLogger.GetInstance().Info(userModel.ToString());

            SecurityService securityService = new SecurityService();

            if (securityService.IsValid(userModel))
            {
                HttpContext.Session.SetString("username", userModel.UserName);

                // MyLogger.GetInstance().Info("Login success");
                return View("LoginSuccess", userModel);
            } else
            {
                HttpContext.Session.Remove("username");

                // MyLogger.GetInstance().Warning("Login failed");
                return View("LoginFailure", userModel);
            }
            
        }
    }
}
