using Plugin.CloudFirestore;
using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DnDApp.Models
{
    public class DatabaseModel
    {
        [Id]
        public string UID { get; set; }

        [Ignored]
        public IDocumentReference Reference { get; set; }
    }
}
