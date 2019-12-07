using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace DnDApp.Maps
{
    public class MapView : ContentView
    {
        private SKCanvasView canvasView;

        public MapView()
        {
            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnPaintSurface;
            Content = canvasView;
        }

        public void OnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(Color.Teal.ToSKColor());
        }
    }
}