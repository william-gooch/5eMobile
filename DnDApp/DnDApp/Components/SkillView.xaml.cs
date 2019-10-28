using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDApp.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillView : ContentView
    {
        public static readonly BindableProperty SkillProperty =
            BindableProperty.Create("Skill", typeof(string), typeof(SkillView), "Acrobatics");
        public string Skill
        {
            get { return (string)GetValue(SkillProperty); }
            set { SetValue(SkillProperty, value); }
        }

        public static readonly BindableProperty ScoreProperty =
            BindableProperty.Create("Score", typeof(int), typeof(SkillView), 0);
        public int Score
        {
            get { return (int)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value); }
        }

        public static readonly BindableProperty ModifierProperty =
            BindableProperty.Create("Modifier", typeof(int), typeof(SkillView), 0);
        public int Modifier
        {
            get { return (int)GetValue(ModifierProperty); }
            set { SetValue(ModifierProperty, value); }
        }

        public SkillView()
        {
            InitializeComponent();
        }
    }
}