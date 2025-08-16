using Microsoft.AspNetCore.Components.Web;
using SkiaSharp;
using SkiaSharp.Views.Blazor;

namespace SkiaSharpDemo.Client.Pages;

public partial class SkiaSharpPage
{

  private void OnPaintCanvasView(SKPaintSurfaceEventArgs args)
  {
  }

  private void OnPaintGLView(SKPaintGLSurfaceEventArgs args)
  {
    SKImageInfo info = args.Info;
    SKSurface surface = args.Surface;
    SKCanvas canvas = surface.Canvas;

    // Clear the canvas
    canvas.Clear(SKColors.White);

    // Create a paint object for drawing
    using (SKPaint paint = new SKPaint())
    {
      paint.Color = SKColors.Blue;
      paint.Style = SKPaintStyle.Fill;

      // Define a rectangle
      SKRect rect = new SKRect(50, 50, 200, 150);

      // Draw the rectangle
      canvas.DrawRect(rect, paint);
    }
  }

  public void OnMouseMove(MouseEventArgs args)
  {
    Console.WriteLine($"OffsetX: {args.OffsetX}  OffsetY: {args.OffsetY}");
  }
}
