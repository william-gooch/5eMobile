using DnDApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticationPage : ContentPage
    {
        IAuthService auth;

        public AuthenticationPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuthService>();
        }

        private async void LogInButton_Clicked(object sender, EventArgs e)
        {
            var email = ((Entry)FindByName("EmailEntry")).Text;
            var password = ((Entry)FindByName("PasswordEntry")).Text;

            try
            {
                await auth.LogIn(email, password);
            }
            catch(Exception exception)
            {
                await DisplayAlert("Error", exception.Message, "Try Again");
                return;
            }
            await Navigation.PopAsync();
        }

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            var email = ((Entry)FindByName("EmailEntry")).Text;
            var password = ((Entry)FindByName("PasswordEntry")).Text;

            try
            {
                await auth.SignUp(email, password);
            }
            catch (Exception exception)
            {
                await DisplayAlert("Error", exception.Message, "Try Again");
                return;
            }
            await Navigation.PopAsync();
        }
    }
}