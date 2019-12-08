using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DnDEngine.Character;
using DnDEngine.Utilities;
using DnDApp.Services;
using Plugin.CloudFirestore;

namespace DnDApp
{
    public partial class MainPage : ContentPage
    {
        public bool IsLoggedIn => Auth.LoggedInUser != null;

        public IAuthService Auth { get; }

        public MainPage()
        {
            Title = "Dungeons and Dragons Companion";
            Auth = DependencyService.Get<IAuthService>();
            InitializeComponent();
        }

        private async void CharactersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterViewer.CharacterList());
        }

        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuthenticationPage());
        }

        private async void MapsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Maps.MapEditPage());
        }

        private void LogOutButton_Clicked(object sender, EventArgs e)
        {
            Auth.LogOut();
        }
    }
}
