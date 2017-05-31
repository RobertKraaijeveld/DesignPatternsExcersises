using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GUIapp
{
  public class GuiManager : IUpdateable, IDrawable
  {
    public GUIElementsIterator elements;
    public GuiManager(System.Action exit)
    {
      var elementsList = new List<GuiElement>();
      elementsList .Add(new Label("A label", new Point(0, 0), 10, Color.Black));
      elementsList .Add(new Button("Click me", new Point(0, 100), 10, Color.Black, 100, 30,
                                                  () => {
                                                    elementsList = new List<GuiElement>();
                                                    elementsList.Add(new Button("Exit", new Point(0, 0), 10, Color.Black, 100, 30,
                                                            () => {
                                                              exit();
                                                            }
                                                            ));
                                                  }
                                                  )); //This action probably doesnt work anymore now
                                                      //Make button labels visible
      
      this.elements = new GUIElementsIterator(elementsList);
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