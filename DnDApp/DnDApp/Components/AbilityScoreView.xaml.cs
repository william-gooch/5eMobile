using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDEngine.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDApp.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbilityScoreView : ContentView
    {
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create("Name", typeof(string), typeof(AbilityScoreView), "Strength");
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly BindableProperty ScoreProperty =
            BindableProperty.Create("Score", typeof(int), typeof(AbilityScoreView), 0);
        public int Score
        {
            get { return (int)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value); }
        }

        public static readonly BindableProperty ModifierProperty =
            BindableProperty.Create("Modifier", typeof(int), typeof(AbilityScoreView), 0);
        public int Modifier
        {
            get { return (int)GetValue(ModifierProperty); }
            set { SetValue(ModifierProperty, value); }
        }

        public AbilityScoreView()
        {
            InitializeComponent();

            Console.WriteLine(this.Name);
        }

        async void OnTapped(object sender, EventArgs args)
        {
            DiceRoll rollPage = new DiceRoll
            {
                Roll = Roll.D(20) + Modifier,
                Text = $"{Name} check:"
            };
            await Navigation.PushModalAsync(rollPage);
        }
    }
}