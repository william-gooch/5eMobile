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
    public partial class CharacterViewer : ContentPage
    {
        public CharacterViewer()
        {
            InitializeComponent();
        }
    }
}