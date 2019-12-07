using Plugin.CloudFirestore;
using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDApp.Models
{
    class Tilemap : DatabaseModel
    {
        [MapTo("width")]
        public int Width { get; set; }

        [MapTo("height")]
        public int Height { get; set; }

        [MapTo("map")]
        public int[] FlattenedMap { get; set; }

        [MapTo("tileset")]
        public IDocumentReference TilesetReference { get; set; }

        [Ignored]
        public Tileset Tileset { get; set; }

        [Ignored]
        public int[,] Map { get; set; }

        public static int[] Flatten(int[,] map)
        {
            int[] flattened = new int[map.Length];

            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    flattened[i * map.GetLength(1) + j] = map[i, j];
                }
            }

            return flattened;
        }

        public static int[,] Reconstruct(int[] flattenedMap, int width, int height)
        {
            int[,] map = new int[height, width];
            int currentTile = 0;
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    map[i, j] = flattenedMap[currentTile];
                    currentTile++;
                }
            }
            return map;
        }
    }
}
