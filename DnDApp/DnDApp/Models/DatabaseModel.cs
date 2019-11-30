using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDApp.Models
{
    public class DatabaseModel
    {
        [Id]
        public string UID { get; set; }
    }
}
