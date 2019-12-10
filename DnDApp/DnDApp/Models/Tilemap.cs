using Plugin.CloudFirestore;
using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDApp.Models
{
    public class Tilemap : DatabaseModel
    {
        [MapTo("name")]
        public string Name { get; set; }

        [MapTo("width")]
        public int Width { get; set; }

        [MapTo("height")]
        public int Height { get; set; }

        [Ignored]
        public int TileWidth { get; set; } = 64;

        [Ignored]
        public int TileHeight { get; set; } = 64;

        [MapTo("map")]
        public IDictionary<string,int> FlattenedMap { get; set; }

        [MapTo("tileset")]
        public IDocumentReference TilesetReference { get; set; }

        [Ignored]
        public Tileset Tileset { get; set; }

        [Ignored]
        public int[,] Map { get; set; }

        public static Tilemap New()
        {
            Tilemap tilemap = new Tilemap
            {
                Name = "New Tilemap",
                Width = 1,
                Height = 1,
                FlattenedMap = new Dictionary<string, int> { ["0"] = 0 },
                TilesetReference = Tileset.DefaultTilesetReference
            };
            return tilemap;
        }

        public static IDictionary<string,int> Flatten(int[,] map)
        {
            IDictionary<string,int> flattened = new Dictionary<string,int>();

            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    flattened[(i * map.GetLength(1) + j).ToString()] = map[i, j];
                }
            }

            return flattened;
        }

        public static int[,] Reconstruct(IDictionary<string,int> flattenedMap, int width, int height)
        {
            int[,] map = new int[height, width];
            int currentTile = 0;
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    map[i, j] = flattenedMap[currentTile.ToString()];
                    currentTile++;
                }
            }
            return map;
        }

        public void Resize(int width, int height)
        {
            int[,] newMap = new int[height, width];
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    if(i < Map.GetLength(0) && j < Map.GetLength(1))
                    {
                        newMap[i, j] = Map[i, j];
                    }
                    else
                    {
                        newMap[i, j] = -1;
                    }
                }
            }
            Map = newMap;
        }
    }
}
