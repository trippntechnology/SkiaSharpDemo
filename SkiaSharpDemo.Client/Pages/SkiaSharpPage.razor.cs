using Microsoft.AspNetCore.Components.Web;
using SkiaSharp;
using SkiaSharp.Views.Blazor;
using SkiaSharpDemo.Client.CanvasObject;
using SkiaSharpDemo.Client.Shared;
using System.Drawing;

namespace SkiaSharpDemo.Client.Pages;

public partial class SkiaSharpPage
{
  private SKGLView? _glView;
  private CanvasObject.CanvasObject? _draggedObject;
  private PointF _lastMousePosition;

  public int Width { get; set; } = 500;
  public int Height { get; set; } = 500;
  public CursorStyle CursorStyle { get; set; } = CursorStyle.Default;

  public List<CanvasObject.CanvasObject> CanvasObjects = new List<CanvasObject.CanvasObject>();
  public string Style => $"border:1px solid blue; cursor:{CursorStyle.ToString().ToLower()};";

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

  public void OnMouseDown(MouseEventArgs args)
  {
    // Pick the topmost object under the mouse cursor
    _draggedObject = CanvasObjects.LastOrDefault(o => o.OnMouseOver(args));
    if (_draggedObject != null)
    {
      _lastMousePosition = new PointF((float)args.OffsetX, (float)args.OffsetY);
      CursorStyle = CursorStyle.Grabbing;
    }
  }

  public void OnMouseMove(MouseEventArgs args)
  {
    if (_draggedObject != null)
    {
      float currentX = (float)args.OffsetX;
      float currentY = (float)args.OffsetY;

      int deltaX = (int)(currentX - _lastMousePosition.X);
      int deltaY = (int)(currentY - _lastMousePosition.Y);

      if (deltaX != 0 || deltaY != 0)
      {
        _draggedObject.Move(deltaX, deltaY);
        _lastMousePosition = new PointF(currentX, currentY);
        _glView?.Invalidate();
      }

      CursorStyle = CursorStyle.Grabbing;
    }
    else
    {
      var objUnderMouse = CanvasObjects.LastOrDefault(o => o.OnMouseOver(args));
      CursorStyle = objUnderMouse != null ? CursorStyle.Grab : CursorStyle.Default;
    }
  }

  public void OnMouseUp(MouseEventArgs args)
  {
    if (_draggedObject != null)
    {
      _draggedObject = null;
      var objUnderMouse = CanvasObjects.LastOrDefault(o => o.OnMouseOver(args));
      CursorStyle = objUnderMouse != null ? CursorStyle.Grab : CursorStyle.Default;
      _glView?.Invalidate();
    }
  }

  public void OnMouseLeave(MouseEventArgs args)
  {
    if (_draggedObject != null)
    {
      _draggedObject = null;
      CursorStyle = CursorStyle.Default;
      _glView?.Invalidate();
    }
  }
}
