using Microsoft.AspNetCore.Components.Web;
using SkiaSharp;
using System.Drawing;

namespace SkiaSharpDemo.Client.CanvasObject;

public class SquareObject(Point topLeft, int width, int height) : CanvasObject
{
  public Point TopLeft { get; set; } = topLeft;
  public int Width { get; set; } = width;
  public int Height { get; set; } = height;

  public override SKPath GetPath()
  {
    var rect = new SKRect(TopLeft.X, TopLeft.Y, TopLeft.X + Width, TopLeft.Y + Height);
    using var builder = new SKPathBuilder();
    builder.AddRect(rect);
    return builder.Detach();
  }

  public override void Move(int deltaX, int deltaY)
  {
    TopLeft = new Point(TopLeft.X + deltaX, TopLeft.Y + deltaY);
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
