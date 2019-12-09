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

namespace DnDApp.Maps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapListPage : ContentPage
    {
        public MapListPage()
        {
            InitializeComponent();
        }
    }

    public class MapListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Tilemap> Maps { get; set; }

        public MapListViewModel()
        {
            Maps = new ObservableCollection<Tilemap>();
            DatabaseService.ObserveTilemaps(
                DependencyService.Get<IAuthService>().LoggedInUser,
                Maps
                );
            Maps.CollectionChanged += (sender, e) =>
            {
                Console.WriteLine("Collection was changed!");
            };
        }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}