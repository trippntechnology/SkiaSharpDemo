using SkiaSharp;
using System.Drawing;

namespace SkiaSharpDemo.Client.CanvasObject;

public class CircleObject(Point midPoint, int radius) : CanvasObject
{
  private readonly Point midPoint = midPoint;
  private readonly int radius = radius;

  public override void OnPaint(SKCanvas canvas)
  {
    using var paint = new SKPaint
    {
      Color = SKColors.Red,
      Style = SKPaintStyle.Fill
    };
    canvas.DrawCircle(midPoint.X, midPoint.Y, radius, paint);
  }
}
