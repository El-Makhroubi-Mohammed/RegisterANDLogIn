using RegisterAndLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Services
{
    public class RegisterService
    {

        UsersDAO usersDAO = new UsersDAO();

        public bool IsValid(UserModel user)
        {
            return usersDAO.RegisterUser(user);
        }
    }
}
