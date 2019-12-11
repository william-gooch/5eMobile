using DnDApp.Models;
using DnDApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDApp.Maps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapEditPage : ContentPage
    {
        public static BindableProperty TilemapProperty =
            BindableProperty.Create("Tilemap", typeof(Tilemap), typeof(MapEditPage));
        public Tilemap Tilemap
        {
            get => (Tilemap)GetValue(TilemapProperty);
            set
            {
                SetValue(TilemapProperty, value);
                widthEntry.Text = value.Width.ToString();
                heightEntry.Text = value.Height.ToString();
                nameEntry.Text = value.Name;
            }
        }

        public MapEditPage()
        {
            InitializeComponent();

            Disappearing += MapEditPage_Disappearing;
        }

        private async void MapEditPage_Disappearing(object sender, EventArgs e)
        {
            await DatabaseService.SaveTilemap(mapView.Tilemap);
        }

        private void PanButton_Clicked(object sender, EventArgs e)
        {
            mapView.CurrentTool = MapTool.PAN;
        }

        private void DrawButton_Clicked(object sender, EventArgs e)
        {
            mapView.CurrentTool = MapTool.DRAW;
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mapView.CurrentTileIndex = mapView.Tilemap.Tileset.Tiles.IndexOf((Tile)e.CurrentSelection.First());
        }

        private void EraseButton_Clicked(object sender, EventArgs e)
        {
            mapView.CurrentTool = MapTool.ERASE;
        }

        private void widthEntry_Unfocused(object sender, FocusEventArgs e)
        {
            int newWidth;
            if (int.TryParse(((Entry)sender).Text, out newWidth))
            {
                Tilemap.Width = newWidth;
                Tilemap.Resize(Tilemap.Width, Tilemap.Height);
            }
        }

        private void heightEntry_Unfocused(object sender, FocusEventArgs e)
        {
            int newHeight;
            if (int.TryParse(((Entry)sender).Text, out newHeight))
            {
                Tilemap.Height = newHeight;
                Tilemap.Resize(Tilemap.Width, Tilemap.Height);
            }
        }

        private void nameEntry_Unfocused(object sender, FocusEventArgs e)
        {
            Tilemap.Name = ((Entry)sender).Text;
        }
    }
}