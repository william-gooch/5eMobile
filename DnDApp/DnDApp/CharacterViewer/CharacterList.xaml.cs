using DnDApp.Models;
using DnDApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            ((CharacterListViewModel)BindingContext).Navigation = this.Navigation;
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
        public INavigation Navigation { get; set; }

        public CharacterListViewModel()
        {
            CharacterTappedCommand = new Command<LightweightCharacterModel>(async (characterModel) =>
            {
                var playerCharacter = await DatabaseService.GetPlayerCharacter(
                    DependencyService.Get<IAuthService>().LoggedInUser,
                    characterModel);

                await Navigation?.PushAsync(new ViewCharacterPage(playerCharacter));
            });
        }

        public ICommand CharacterTappedCommand { get; set; }

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