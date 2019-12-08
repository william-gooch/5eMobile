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

        private SKMatrix TemporaryTransformMatrix { get; set; }
        private SKMatrix CurrentTransformMatrix { get; set; }

        public Tilemap Tilemap
        {
            get => (Tilemap)GetValue(TilemapProperty);
            set
            {
                SetValue(TilemapProperty, value);
                canvasView.InvalidateSurface();
            }
        }

        public static BindableProperty CurrentToolProperty =
            BindableProperty.Create("CurrentTool", typeof(MapTool), typeof(MapView), MapTool.PAN);
        public MapTool CurrentTool {
            get => (MapTool)GetValue(CurrentToolProperty);
            set => SetValue(CurrentToolProperty, value);
        }

        // the index of the current tile in the tileset.
        public int CurrentTileIndex { get; set; }

        public MapView()
        {
            // temporary test code!
            LoadTilemapFromDatabase();

            canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnPaintSurface;
            canvasView.EnableTouchEvents = true;
            canvasView.Touch += OnDrawTool;
            Content = canvasView;

            CurrentTransformMatrix = SKMatrix.MakeIdentity();
            TemporaryTransformMatrix = SKMatrix.MakeIdentity();

            CurrentTileIndex = 0;

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanTool;
            GestureRecognizers.Add(panGesture);

            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += OnZoom;
            GestureRecognizers.Add(pinchGesture);
        }

        private void OnZoom(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (CurrentTool == MapTool.PAN)
            {
                if(e.Status == GestureStatus.Running)
                {
                    var tempMatrix = new SKMatrix();
                    float scaleX = (float)e.Scale;
                    float scaleY = (float)e.Scale;
                    float pivotX = (float)e.ScaleOrigin.X * canvasView.CanvasSize.Width;
                    float pivotY = (float)e.ScaleOrigin.Y * canvasView.CanvasSize.Height;
                    SKMatrix.Concat(ref tempMatrix,
                        SKMatrix.MakeScale(scaleX, scaleY, pivotX, pivotY),
                        TemporaryTransformMatrix);
                    TemporaryTransformMatrix = tempMatrix;
                    CurrentTransformMatrix = tempMatrix;
                    canvasView.InvalidateSurface();
                }
            }
        }

        private void OnPanTool(object sender, PanUpdatedEventArgs e)
        {
            if (CurrentTool == MapTool.PAN)
            {
                if (e.StatusType == GestureStatus.Running)
                {
                    var tempMatrix = new SKMatrix();
                    float transX = (float)(e.TotalX * (canvasView.CanvasSize.Width / canvasView.Width));
                    float transY = (float)(e.TotalY * (canvasView.CanvasSize.Height / canvasView.Height));
                    SKMatrix.Concat(ref tempMatrix,
                        SKMatrix.MakeTranslation(transX, transY),
                        CurrentTransformMatrix);
                    TemporaryTransformMatrix = tempMatrix;
                    canvasView.InvalidateSurface();
                }
                else if (e.StatusType == GestureStatus.Completed)
                {
                    CurrentTransformMatrix = TemporaryTransformMatrix;
                }
            }
        }

        private void OnDrawTool(object sender, SKTouchEventArgs e)
        {
            if(CurrentTool == MapTool.DRAW)
            {
                if(e.ActionType == SKTouchAction.Pressed || e.ActionType == SKTouchAction.Moved)
                {
                    var inverseMatrix = new SKMatrix();
                    CurrentTransformMatrix.TryInvert(out inverseMatrix);
                    var transformedLocation = inverseMatrix.MapPoint(e.Location);
                    int col = (int)Math.Floor(transformedLocation.X / Tilemap.TileWidth);
                    int row = (int)Math.Floor(transformedLocation.Y / Tilemap.TileHeight);

                    if(col >= Tilemap.Width || row >= Tilemap.Height)
                    {
                        return;
                    }

                    if(Tilemap.Map[row,col] != CurrentTileIndex)
                    {
                        Tilemap.Map[row, col] = CurrentTileIndex;
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
                canvas.SetMatrix(TemporaryTransformMatrix);
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

                    canvas.DrawImage(tile.SkiaImage, new SKRect(x, y, x + Tilemap.TileWidth, y + Tilemap.TileHeight));
                }
            }
        }
    }
}