using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DnDApp.Models
{
    public class DatabaseModel : BindableObject
    {
        [Id]
        public string UID { get; set; }
    }
}
