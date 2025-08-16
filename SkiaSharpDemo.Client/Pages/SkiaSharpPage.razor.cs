using Microsoft.AspNetCore.Components.Web;
using SkiaSharp;
using SkiaSharp.Views.Blazor;
using SkiaSharpDemo.Client.CanvasObject;
using System.Drawing;

namespace SkiaSharpDemo.Client.Pages;

public partial class SkiaSharpPage
{
  public int Width { get; set; } = 500;
  public int Height { get; set; } = 500;
  public List<CanvasObject.CanvasObject> CanvasObjects = new List<CanvasObject.CanvasObject>();

  public SkiaSharpPage()
  {
    // Add several CircleObject and SquareObject instances with different positions and sizes
    CanvasObjects.Add(new CircleObject(new Point(100, 100), 40));
    CanvasObjects.Add(new CircleObject(new Point(300, 200), 60));
    CanvasObjects.Add(new SquareObject(new Point(200, 50), 80, 80));
    CanvasObjects.Add(new SquareObject(new Point(350, 300), 50, 100));
  }

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
    foreach (var obj in CanvasObjects)
    {
      obj.OnPaint(canvas);
    }
  }

  public void OnMouseMove(MouseEventArgs args)
  {
    Console.WriteLine($"OffsetX: {args.OffsetX}  OffsetY: {args.OffsetY}");
  }
}
