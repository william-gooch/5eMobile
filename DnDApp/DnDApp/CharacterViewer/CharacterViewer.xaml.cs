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
            ((CharacterViewerModel)BindingContext).Character = character;
        }
    }

    public class CharacterViewerModel : BindableObject
    {
        private PlayerCharacter character;
        public PlayerCharacter Character
        {
            get {
                if (character == null)
                {
                    Character = new PlayerCharacter("Jorgen Windhelm",
                        new AbilityScores(0,0,0,0,0,0),
                        new CharacterRace.Dragonborn(),
                        new CharacterClass.Barbarian(),
                        new CharacterBackground.Acolyte());
                }
                return character;
            }
            set {
                character = value;
                OnPropertyChanged("Character");
            }
        }

        public string RaceClassText => $"{Character.Race.Name} {Character.Class.Name} (1)";
    }
}