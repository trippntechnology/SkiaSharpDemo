using Microsoft.AspNetCore.Components.Web;
using SkiaSharp;
using System.Drawing;

namespace SkiaSharpDemo.Client.CanvasObject;

public class CircleObject(Point midPoint, int radius) : CanvasObject
{
  private readonly Point midPoint = midPoint;
  private readonly int radius = radius;

  public override SKPath GetPath()
  {
    var path = new SKPath();
    path.AddCircle(midPoint.X, midPoint.Y, radius);
    return path;
  }

  public override void OnPaint(SKCanvas canvas)
  {
    using var paint = new SKPaint
    {
      Color = SKColors.Red,
      Style = SKPaintStyle.Fill
    };
    using var path = GetPath();
    canvas.DrawPath(path, paint);
  }
}
