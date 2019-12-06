using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDApp.Models
{
    public class Tile
    {
        [MapTo("name")]
        public string Name { get; set; }

        [MapTo("imageUrl")]
        public string ImageURL { get; set; }
    }
}
