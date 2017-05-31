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
               element.action();
            }
            else
            {
                element.color = Color.AliceBlue;
            }
        }
        public void UpdateLabel(Label element, float dt) 
        {
            //Console.WriteLine("Updating label");
        }

        public void UpdateGui(GuiManager gui_manager, float dt)
        {
            gui_manager.elements.Reset();
            

            //Continue if visit is true, which is done when getNext returns a some, meaning there are elementsLeft
            while (gui_manager.elements.GetNext().Visit(() => false, _ => true))
            {
                //First arg is onNone, second arg is onSome
                gui_manager.elements.GetNext().Visit(() => { }, item => { item.Update(this, dt); });
            }
        }
    }
}