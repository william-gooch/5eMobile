using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Title = "Dungeons and Dragons Companion";
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterViewer.CharacterViewer());
        }
    }
}
