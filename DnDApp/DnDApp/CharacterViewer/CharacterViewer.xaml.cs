using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DnDEngine.Character;
using DnDEngine.Utilities;
using System.ComponentModel;

namespace DnDApp.CharacterViewer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterViewer : ContentPage
    {

        public CharacterViewer(PlayerCharacter character)
        {
            InitializeComponent();
            BindingContext = new CharacterViewerModel { Character = character };
        }
    }

    public class CharacterViewerModel : BindableObject
    {
        private PlayerCharacter character;
        public PlayerCharacter Character
        {
            get { return character; }
            set { character = value; OnPropertyChanged("Character"); }
        }

        public AbilityScores AbilityScores => Character.BaseAbilityScores;
        public string Name => Character.Name;
        public string Race => Character.Race.Name;
        public string Class => Character.Class.Name;
        public string Background => Character.Background.Name;
        public int ArmorClass => Character.ArmorClass;

        public string RaceClassText => $"{Race} {Class} (1)";
    }
}