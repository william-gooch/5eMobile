using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Plugin.FirebaseStorage;
using Xamarin.Forms;
using System.IO;
using SkiaSharp;
using System.Threading.Tasks;

namespace DnDApp.Models
{
    public class Tile
    {
        [MapTo("name")]
        public string Name { get; set; }

        [MapTo("imageUrl")]
        public string ImageURL { get; set; }

        public ImageSource ImgSource { get; private set; }
        public SKImage SkiaImage { get; private set; }

        public async Task LoadImageAsync()
        {
            Stream stream = await CrossFirebaseStorage.Current.Instance
                .GetReferenceFromPath(ImageURL)
                .GetStreamAsync();
            ImgSource = ImageSource.FromStream(() => stream);
            SkiaImage = SKImage.FromEncodedData(stream);
        }
    }
}
