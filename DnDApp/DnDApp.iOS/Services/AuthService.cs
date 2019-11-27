using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDApp.iOS.Services;
using DnDApp.Services;
using Firebase.Auth;
using Foundation;
using UIKit;

using Xamarin.Forms
using User = DnDApp.Services.User;

[assembly: Dependency(typeof(AuthService))]
namespace DnDApp.iOS.Services
{
    class AuthService : IAuthService
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public async Task<User> LogIn(string email, string password)
        {
            try
            {
                var res = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                var uid = res.User.Uid;
                var emailAddr = res.User.Email;

                LoggedInUser = new User { UID = uid, Email = email };
                return LoggedInUser;
            }
            catch (NSErrorException e)
            {
                switch((AuthErrorCode)((long)e.Code))
                {
                    case AuthErrorCode.UserDisabled: Console.WriteLine("The user's account is disabled."); break;
                    case AuthErrorCode.WrongPassword: Console.WriteLine("Incorrect password."); break;
                    case AuthErrorCode.InvalidEmail: Console.WriteLine("Invalid email."); break;
                    default: Console.WriteLine("Unknown error occured!"); break;
                }
                throw e;
            }
        }

        public async Task<User> SignUp(string email, string password)
        {
            try
            {
                var res = await Auth.DefaultInstance.CreateUserAsync(email, password);
                var uid = res.User.Uid;
                var emailAddr = res.User.Email;

                LoggedInUser = new User { UID = uid, Email = email };
                return LoggedInUser;
            }
            catch (NSErrorException e)
            {
                switch ((AuthErrorCode)((long)e.Code))
                {
                    case AuthErrorCode.EmailAlreadyInUse: Console.WriteLine("Email already in use."); break;
                    case AuthErrorCode.InvalidEmail: Console.WriteLine("Invalid email."); break;
                    case AuthErrorCode.WeakPassword: Console.WriteLine("Password is too weak."); break;
                    default: Console.WriteLine("Unknown error occured!"); break;
                }
                throw e;
            }
        }

        public void LogOut()
        {
            Auth.DefaultInstance.SignOut(out _);
            LoggedInUser = null;
        }

        private User _loggedInUser;
        public User LoggedInUser
        {
            get
            {
                if (_loggedInUser == null)
                {
                    var firebaseUser = Auth.DefaultInstance.CurrentUser;
                    if (firebaseUser == null)
                    {
                        return null;
                    }

                    var uid = firebaseUser.Uid;
                    var email = firebaseUser.Email;

                    _loggedInUser = new User { UID = uid, Email = email };
                }
                return _loggedInUser;
            }

            private set
            {
                _loggedInUser = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoggedInUser"));
            }
        }
    }
}