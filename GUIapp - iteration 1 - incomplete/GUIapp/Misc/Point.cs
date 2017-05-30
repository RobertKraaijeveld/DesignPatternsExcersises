using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace GUIapp
{
  public class Point
  {
    public Point(float x, float y)
    {
      this.X = x;
      this.Y = y;
    }
    public float X { get; set; }
    public float Y { get; set; }
  }
}



