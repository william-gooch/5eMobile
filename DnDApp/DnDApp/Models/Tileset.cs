using Plugin.CloudFirestore;
using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Models
{
    public class Tileset : DatabaseModel
    {
        [MapTo("name")]
        public string Name { get; set; }

        [MapTo("tiles")]
        public List<Tile> Tiles { get; set; }

        public static IDocumentReference DefaultTilesetReference =
            CrossCloudFirestore.Current.Instance.GetDocument("/tilesets/olmmDyX6l96Mu6yPzbGD");

        public Tile this[string name]
        {
            get => (from tile in Tiles
                    where tile.Name == name
                    select tile).First();
        }

        public Tile this[int index]
        {
            get => Tiles[index];
            set => Tiles[index] = value;
        }

        public async Task LoadImagesAsync()
        {
            var taskList = new List<Task>();
            foreach(Tile tile in Tiles)
            {
                taskList.Add(tile.LoadImageAsync());
            }
            await Task.WhenAll(taskList);
        }
    }
}
