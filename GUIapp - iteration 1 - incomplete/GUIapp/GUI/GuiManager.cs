using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GUIapp
{
  public class GuiManager : IUpdateable, IDrawable
  {
    public List<GuiElement> elements;
    public GuiManager(System.Action exit)
    {
      elements = new List<GuiElement>();
      elements.Add(new Label("Hi Ahmed!", new Point(0, 0), 10, Color.Black));
      elements.Add(new Button("Click me", new Point(0, 100), 10, Color.Black, 100, 30,
                                                  () => {
                                                    elements = new List<GuiElement>();
                                                    elements.Add(new Button("Exit", new Point(0, 0), 10, Color.Black, 100, 30,
                                                            () => {
                                                              exit();
                                                            }
                                                            ));
                                                  }
                                                  ));
    }

    public void Draw(IDrawVisitor visitor)
    {
      visitor.DrawGui(this);
    }
    
    public void Update(IUpdateVisitor visitor, float dt)
    {
      visitor.UpdateGui(this, dt);
    }
  }
}