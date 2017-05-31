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
      elementsList .Add(new Label("I returned, and saw under the sun, that the race is not to the swift, \n" +
                                  "nor the battle to the strong, neither yet bread to the wise, \n" +
                                  "nor yet riches to men of understanding, nor yet favour to men of skill; \n" +
                                  "but time and chance happeneth to them all. \n", 
                                  new Point(0, 0), 10, Color.Black));
      
      elementsList .Add(new Button("Quit", new Point(0, 100), 10, Color.Black, 100, 30, () => { exit(); } )); 
      
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