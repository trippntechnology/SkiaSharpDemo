using Microsoft.AspNetCore.Components.Web;
using SkiaSharp;

namespace SkiaSharpDemo.Client.CanvasObject;

public abstract class CanvasObject
{
  public abstract void OnPaint(SKCanvas canvas);
  public abstract SKPath GetPath();

  public virtual bool OnMouseOver(MouseEventArgs args)
  {
    // Get mouse coordinates from MouseEventArgs
    float mouseX = (float)args.OffsetX;
    float mouseY = (float)args.OffsetY;

    // Get the path of the square
    using var path = GetPath();

    // Check if the mouse point is inside the path
    return path.Contains(mouseX, mouseY);
  }
}
