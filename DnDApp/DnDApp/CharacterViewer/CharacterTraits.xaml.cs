using DnDEngine.Character;
using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDApp.CharacterViewer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterTraits : ContentPage
    {
        public CharacterTraits()
        {
            InitializeComponent();
        }
    }

    public class CharacterTraitsModel : BindableObject
    {
        private PlayerCharacter character;

        public PlayerCharacter Character
        {
            get
            {
                if (character == null)
                {
                    Character = new PlayerCharacter("Jorgen Windhelm",
                        new AbilityScores(0, 0, 0, 0, 0, 0),
                        new CharacterRace.Dragonborn(),
                        new CharacterClass.Barbarian(),
                        new CharacterBackground.Acolyte());
                }
                return character;
            }
            set
            {
                character = value;
                OnPropertyChanged("Character");
            }
        }
    }
}