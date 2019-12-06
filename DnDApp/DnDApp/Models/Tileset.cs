using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnDApp.Models
{
    public class Tileset : DatabaseModel
    {
        [MapTo("name")]
        public string Name { get; set; }

        [MapTo("tiles")]
        public List<Tile> Tiles { get; set; }

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
    }
}
