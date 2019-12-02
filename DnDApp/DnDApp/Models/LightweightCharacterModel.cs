using Plugin.CloudFirestore;
using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDApp.Models
{
    public class LightweightCharacterModel : DatabaseModel
    {
        [MapTo("name")]
        public string Name { get; set; }

        [MapTo("race")]
        public IDocumentReference RaceRef { get; set; }

        [MapTo("raceName")]
        public string RaceName { get; set; }

        [MapTo("class")]
        public IDocumentReference ClassRef { get; set; }

        [MapTo("className")]
        public string ClassName { get; set; }

        [MapTo("background")]
        public IDocumentReference BackgroundRef { get; set; }

        [MapTo("backgroundName")]
        public string BackgroundName { get; set; }
    }
}
