using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DnDApp.Droid.Services;
using DnDApp.Services;
using Firebase.Auth;

using Xamarin.Forms;

[assembly: Dependency(typeof(AuthService))]
namespace DnDApp.Droid.Services
{
    class AuthService : IAuthService
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public async Task<User> LogIn(string email, string password)
        {
            try
            {
                var res = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var uid = res.User.Uid;
                var emailAddr = res.User.Email;

                LoggedInUser = new User { UID = uid, Email = emailAddr };
                return LoggedInUser;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                Console.WriteLine("User does not exist");
                throw e;
            }
            catch(FirebaseAuthInvalidCredentialsException e)
            {
                Console.WriteLine("Invalid password");
                throw e;
            }
        }

        public async Task<User> SignUp(string email, string password)
        {
            try
            {
                var res = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                var uid = res.User.Uid;
                var emailAddr = res.User.Email;

                LoggedInUser = new User { UID = uid, Email = emailAddr };
                return LoggedInUser;
            }
            catch(FirebaseAuthWeakPasswordException e)
            {
                Console.WriteLine("The password entered is too weak.");
                throw e;
            }
            catch(FirebaseAuthInvalidCredentialsException e)
            {
                Console.WriteLine("Invalid email address.");
                throw e;
            }
            catch(FirebaseAuthUserCollisionException e)
            {
                Console.WriteLine("Account already exists.");
                throw e;
            }
        }

        public void LogOut()
        {
            FirebaseAuth.Instance.SignOut();
            LoggedInUser = null;
        }

        private User _loggedInUser;
        public User LoggedInUser {
            get {
                if (_loggedInUser == null)
                {
                    var firebaseUser = FirebaseAuth.Instance.CurrentUser;
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