using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DnDEngine.Character;
using DnDEngine.Utilities;

namespace DnDApp
{
    public partial class MainPage : ContentPage
    {
        private PlayerCharacter character =
            new PlayerCharacter("Jorgen Windhelm", new AbilityScores(20, 19, 18, 17, 16, 15),
                new CharacterRace.Dragonborn(), new CharacterClass.Barbarian(), new CharacterBackground.Acolyte());

        public MainPage()
        {
            Title = "Dungeons and Dragons Companion";
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterViewer.CharacterViewer(character));
        }
    }
}
