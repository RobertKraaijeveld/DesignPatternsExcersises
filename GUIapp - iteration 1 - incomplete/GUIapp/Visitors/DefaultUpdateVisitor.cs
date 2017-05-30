using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GUIapp
{
    public class DefaultUpdateVisitor : IUpdateVisitor
    {
        //what to do with deltatime?
        public void UpdateButton(Button element, float dt)
        {
            var mouse = Mouse.GetState();
            
            if(mouse.LeftButton == ButtonState.Pressed
               && element.is_intersecting(new Point(mouse.Position.X, mouse.Position.Y)))
            {
                element.color = Color.Red;
            }
            else
            {
                element.color = Color.White;
            }
        }
        public void UpdateLabel(Label element, float dt) 
        {
            Console.WriteLine("Updating label");
        }

        public void UpdateGui(GuiManager gui_manager, float dt)
        {
            gui_manager.elements.ForEach(elem => elem.Update(this, dt));
        }
    }
}