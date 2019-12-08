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
    public enum MapTool
    {
        PAN,
        DRAW
    }

    public class MapView : ContentView
    {
        private SKCanvasView canvasView;

        public static readonly BindableProperty TilemapProperty =
            BindableProperty.Create("Tilemap", typeof(Tilemap), typeof(MapView));

        public (double x, double y) CurrentPan { get; set; }

        public Tilemap Tilemap
        {
            get => (Tilemap)GetValue(TilemapProperty);
            set
            {
                SetValue(TilemapProperty, value);
                canvasView.InvalidateSurface();
            }
        }

        public MapTool CurrentTool { get; set; }

        // the index of the current tile in the tileset.
        public int CurrentTileSelected { get; set; }

        public MapView()
        {
            // temporary test code!
            LoadTilemapFromDatabase();

            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnPaintSurface;
            canvasView.EnableTouchEvents = true;
            canvasView.Touch += OnDrawTool;
            Content = canvasView;

            CurrentTool = MapTool.DRAW;
            CurrentTileSelected = 0;

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanTool;
            GestureRecognizers.Add(panGesture);
        }

        private void OnPanTool(object sender, PanUpdatedEventArgs e)
        {
            if (CurrentTool == MapTool.PAN)
            {
                if (e.StatusType == GestureStatus.Running)
                {
                    canvasView.TranslationX = CurrentPan.x + e.TotalX;
                    canvasView.TranslationY = CurrentPan.y + e.TotalY;
                }
                else if (e.StatusType == GestureStatus.Completed)
                {
                    CurrentPan = (canvasView.TranslationX, canvasView.TranslationY);
                }
            }
        }

        private void OnDrawTool(object sender, SKTouchEventArgs e)
        {
            if(CurrentTool == MapTool.DRAW)
            {
                if(e.ActionType == SKTouchAction.Pressed || e.ActionType == SKTouchAction.Moved)
                {
                    int col = (int)Math.Floor(e.Location.X / Tilemap.TileWidth);
                    int row = (int)Math.Floor(e.Location.Y / Tilemap.TileHeight);

                    if(col >= Tilemap.Width || row >= Tilemap.Height)
                    {
                        return;
                    }

                    if(Tilemap.Map[row,col] != CurrentTileSelected)
                    {
                        Tilemap.Map[row, col] = CurrentTileSelected;
                        canvasView.InvalidateSurface();
                    }
                }
                e.Handled = true;
            }
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

            canvas.Clear(Color.Transparent.ToSKColor());

            if (Tilemap != null)
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