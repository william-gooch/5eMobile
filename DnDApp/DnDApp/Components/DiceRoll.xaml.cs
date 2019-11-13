using System;
using System.Collections.Generic;
using DnDEngine.Utilities;
using Xamarin.Forms;

namespace DnDApp.Components
{
    public partial class DiceRoll : ContentPage
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(DiceRoll), "");
        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

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
