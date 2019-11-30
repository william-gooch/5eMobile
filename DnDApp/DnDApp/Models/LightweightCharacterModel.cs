﻿using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDApp.Models
{
    class LightweightCharacterModel : DatabaseModel
    {
        [MapTo("name")]
        public string Name { get; set; }

        [MapTo("raceName")]
        public string RaceName { get; set; }

        [MapTo("className")]
        public string ClassName { get; set; }

        [MapTo("backgroundName")]
        public string BackgroundName { get; set; }
    }
}
