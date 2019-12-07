using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using DnDApp.Models;
using DnDApp.Services;
using Plugin.CloudFirestore;
using System.Threading.Tasks;
using System.Threading;

namespace DnDApp.Maps
{
    public class MapView : ContentView
    {
        private SKCanvasView canvasView;

        public static readonly BindableProperty TilemapProperty =
            BindableProperty.Create("Tilemap", typeof(Tilemap), typeof(MapView));

        public Tilemap Tilemap
        {
            get => (Tilemap)GetValue(TilemapProperty);
            set {
                SetValue(TilemapProperty, value);
                canvasView.InvalidateSurface();
            }
        }

        public MapView()
        {
            // temporary test code!
            LoadTilemapFromDatabase();
            
            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnPaintSurface;
            Content = canvasView;
        }

        public async void LoadTilemapFromDatabase()
        {
            Tilemap = await DatabaseService.GetTilemap(
                CrossCloudFirestore.Current.Instance.GetDocument("/users/hhd7yBMCPjXtmDr0dwnsiHaU8I83/tilemaps/GhKuOoAUdTa9FSD6xDPU")
            );
        }

        public void OnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(Color.Black.ToSKColor());

            if(Tilemap != null)
            {
                DrawTilemap(canvas);
            }
            else
            {
                string loadingMessage = "Loading...";
                var textPaint = new SKPaint { Color = Color.White.ToSKColor(), TextSize = 40 };
                var textBounds = new SKRect();
                textPaint.MeasureText(loadingMessage, ref textBounds);
                canvas.DrawText(loadingMessage, info.Width / 2 - textBounds.Width / 2, info.Height / 2 - textBounds.Height / 2, textPaint);
            }
        }

        public void DrawTilemap(SKCanvas canvas)
        {
            SKPaint blackPaint = new SKPaint { Color = Color.Black.ToSKColor() };
            SKPaint whitePaint = new SKPaint { Color = Color.White.ToSKColor() };

            for (int row = 0; row < Tilemap.Height; row++)
            {
                int y = row * Tilemap.TileHeight;
                for (int col = 0; col < Tilemap.Width; col++)
                {
                    int x = col * Tilemap.TileWidth;

                    int tileIndex = Tilemap.Map[row, col];
                    Tile tile = Tilemap.Tileset[tileIndex];

                    // temporary test code!
                    if (tileIndex == 0)
                    {
                        canvas.DrawRect(x, y, Tilemap.TileWidth, Tilemap.TileHeight, blackPaint);
                    }
                    else
                    {
                        canvas.DrawRect(x, y, Tilemap.TileWidth, Tilemap.TileHeight, whitePaint);
                    }
                }
            }
        }
    }
}