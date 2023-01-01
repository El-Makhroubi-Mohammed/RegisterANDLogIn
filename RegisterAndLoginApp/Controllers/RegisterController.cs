using Microsoft.AspNetCore.Mvc;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterProcess(UserModel userModel)
        {
            RegisterService register = new RegisterService();
            if (register.IsValid(userModel))
            {
                return View("RegisterValid", userModel);
            } else
            {
                return View("RegisterFailed", userModel);
            }
        }
    }
}
