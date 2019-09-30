using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DnDEngine.Utilities;

namespace DnDApp.CharacterViewer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterViewer : ContentPage
    {
        private AbilityScores abilityScores = new AbilityScores(20, 19, 18, 17, 16, 15);

        public AbilityScores AbilityScores
        {
            get { return abilityScores; }
            set { abilityScores = value; }
        }

        public CharacterViewer()
        {
            InitializeComponent();
        }
    }
}