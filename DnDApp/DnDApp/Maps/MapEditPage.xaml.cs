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
        public MapEditPage()
        {
            InitializeComponent();

            Disappearing += MapEditPage_Disappearing;
        }

        private async void MapEditPage_Disappearing(object sender, EventArgs e)
        {
            await DatabaseService.SaveTilemap(mapView.Tilemap, mapView.TilemapRef);
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
    }
}