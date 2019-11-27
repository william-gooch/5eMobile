using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DnDEngine.Character;
using DnDEngine.Utilities;
using DnDApp.Services;

namespace DnDApp
{
    public partial class MainPage : ContentPage
    {
        private PlayerCharacter character =
            new PlayerCharacter("Jorgen Windhelm", new AbilityScores(20, 19, 18, 17, 16, 15),
                new CharacterRace.Dragonborn(), new CharacterClass.Barbarian(), new CharacterBackground.Acolyte());

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
            await Navigation.PushAsync(new CharacterViewer.ViewCharacterPage(character));
        }

        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuthenticationPage());
        }

        private void LogOutButton_Clicked(object sender, EventArgs e)
        {
            Auth.LogOut();
        }
    }
}
