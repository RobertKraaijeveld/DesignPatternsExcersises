using System;
using GUIapp.FrameworkAdapter;

namespace GUIapp
{
  public class Label : GuiElement
  {
    public string content;
    public int size;
    public MonoGameColor color;
    public Point top_left_corner;

    public Label(string content, Point top_left_corner, int size, MonoGameColor color)
    {
      this.size = size;
      this.color = color;
      this.content = content;
      this.top_left_corner = top_left_corner;

    }

    public void Draw(IDrawVisitor visitor)
    {
      visitor.DrawLabel(this);
    }

    public void Update(IUpdateVisitor visitor, float dt)
    {
      visitor.UpdateLabel(this, dt);
    }
    
  }


  public class Button : GuiElement
  {
    public int width, height;
    public Action action;
    public MonoGameColor color;
    public Label label;
    public Point top_left_corner;

    public Button(string text, Point top_left_corner, int size, MonoGameColor color, int width, int height, Action action) 
    {
      this.action = action;
      this.width = width;
      this.height = height;
      this.color = color;
      this.top_left_corner = top_left_corner;
      
      label = new Label(text, top_left_corner, size, color);
    }


    public void Draw(IDrawVisitor visitor)
    {
      visitor.DrawButton(this);
    }


    public bool is_intersecting(Point point)
    {
      return point.X > top_left_corner.X && point.Y > top_left_corner.Y &&
             point.X < top_left_corner.X + width && point.Y < top_left_corner.Y + height;
    }


    public void Update(IUpdateVisitor visitor, float dt)
    {
      visitor.UpdateButton(this, dt);
    }
  }
}
