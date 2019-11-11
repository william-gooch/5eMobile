using System;
using System.Collections.Generic;
using DnDEngine.Utilities;
using Xamarin.Forms;

namespace DnDApp.Components
{
    public partial class DiceRoll : ContentPage
    {
        public DiceRoll()
        {
            InitializeComponent();
        }

        void OnClose(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }
    }
}
