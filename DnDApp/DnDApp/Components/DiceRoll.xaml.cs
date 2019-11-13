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

        public static readonly BindableProperty RollProperty =
            BindableProperty.Create("Roll", typeof(Roll), typeof(DiceRoll));
        public Roll Roll
        {
            get { return (Roll)GetValue(RollProperty); }
            set { SetValue(RollProperty, value); }
        }

        public DiceRoll()
        {
            InitializeComponent();
        }

        void OnClose(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }

        void OnReroll(object sender, EventArgs args)
        {
            Roll.DoRoll();
            OnPropertyChanged("Roll");
        }
    }
}
