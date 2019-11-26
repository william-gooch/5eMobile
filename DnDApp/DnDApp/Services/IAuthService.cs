using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Services
{
    interface IAuthService
    {
        Task<User> SignUp(string email, string password);
        Task<User> LogIn(string email, string password);
    }
}
