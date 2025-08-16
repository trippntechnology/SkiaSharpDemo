using SkiaSharp;
using System.Drawing;

namespace SkiaSharpDemo.Client.CanvasObject;

public class SquareObject(Point topLeft, int width, int height) : CanvasObject
{
  private readonly Point topLeft = topLeft;
  private readonly int width = width;
  private readonly int height = height;

  public override void OnPaint(SKCanvas canvas)
  {
    using var paint = new SKPaint
    {
      Color = SKColors.Green,
      Style = SKPaintStyle.Fill
    };
    var rect = new SKRect(topLeft.X, topLeft.Y, topLeft.X + width, topLeft.Y + height);
    canvas.DrawRect(rect, paint);
  }
}
