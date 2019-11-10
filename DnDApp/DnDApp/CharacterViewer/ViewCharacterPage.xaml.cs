using DnDEngine.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDApp.CharacterViewer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCharacterPage : TabbedPage
    {
        public ViewCharacterPage(PlayerCharacter character)
        {
            InitializeComponent();

            Children.Add(new CharacterViewer(character));
            Children.Add(new CharacterTraits());
        }
    }
}