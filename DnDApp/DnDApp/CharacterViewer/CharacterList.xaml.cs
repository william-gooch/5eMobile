using DnDApp.Models;
using DnDApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDApp.CharacterViewer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterList : ContentPage
    {
        public CharacterList()
        {
            InitializeComponent();
            Task.Run(async () => {
                var currentUser = DependencyService.Get<IAuthService>().LoggedInUser;
                if (currentUser == null) return;
                var characters = await DatabaseService.GetCharacters(currentUser);
                Device.BeginInvokeOnMainThread(() => {
                    ((CharacterListViewModel)BindingContext).Characters =
                        new ObservableCollection<LightweightCharacterModel>(characters);
                });
            });
        }
    }

    public class CharacterListViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<LightweightCharacterModel> _characters;
        public ObservableCollection<LightweightCharacterModel> Characters {
            get => _characters;
            set
            {
                _characters = value;
                RaisePropertyChanged("Characters");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}