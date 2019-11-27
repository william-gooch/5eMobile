using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Services
{
    interface IAuthService
    {
        /// <summary>
        /// Sign up a new user with an email and a password.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The new user that was created.</returns>
        Task<User> SignUp(string email, string password);

        /// <summary>
        /// Log in an existing user with an email and a password.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The user that was logged in.</returns>
        Task<User> LogIn(string email, string password);

        /// <summary>
        /// Gets the currently logged in user, or null if there is no user logged in.
        /// </summary>
        User LoggedInUser { get; }
    }
}
