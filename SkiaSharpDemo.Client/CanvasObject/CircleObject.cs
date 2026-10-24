using Microsoft.AspNetCore.Components.Web;
using SkiaSharp;
using System.Drawing;

namespace SkiaSharpDemo.Client.CanvasObject;

public class CircleObject(Point midPoint, int radius) : CanvasObject
{
  public Point MidPoint { get; set; } = midPoint;
  public int Radius { get; set; } = radius;

  public override SKPath GetPath()
  {
    using var builder = new SKPathBuilder();
    builder.AddCircle(MidPoint.X, MidPoint.Y, Radius);
    return builder.Detach();
  }

  public override void Move(int deltaX, int deltaY)
  {
    MidPoint = new Point(MidPoint.X + deltaX, MidPoint.Y + deltaY);
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
