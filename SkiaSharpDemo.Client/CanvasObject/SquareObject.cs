using Microsoft.AspNetCore.Components.Web;
using SkiaSharp;
using System.Drawing;

namespace SkiaSharpDemo.Client.CanvasObject;

public class SquareObject(Point topLeft, int width, int height) : CanvasObject
{
  private readonly Point topLeft = topLeft;
  private readonly int width = width;
  private readonly int height = height;

  public override SKPath GetPath()
  {
    var rect = new SKRect(topLeft.X, topLeft.Y, topLeft.X + width, topLeft.Y + height);
    var path = new SKPath();
    path.AddRect(rect);
    return path;
  }

  public override void OnPaint(SKCanvas canvas)
  {
    using var paint = new SKPaint
    {
      Color = SKColors.Green,
      Style = SKPaintStyle.Fill
    };
    using var path = GetPath();
    canvas.DrawPath(path, paint);
  }
}
