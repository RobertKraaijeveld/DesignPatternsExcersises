using System;
using GUIapp.FrameworkAdapter;
using Microsoft.Xna.Framework.Graphics;

namespace GUIapp.GuiDecorators
{
    public class ClickableDecorator : GuiElementDecorator
    {
        //These are public, which sucks
        private System.Action onClickAction;
        private Point position;
        private int width, height;

        public ClickableDecorator(IGuiElement elementToBeDecorated, Action onClickAction, Point position, int width, int height) 
                                  : base(elementToBeDecorated)
        {
            this.onClickAction = onClickAction;
            this.position = position;
            this.width = width;
            this.height = height;
        }

        
        public override void Draw(IElementVisitor visitor)
        {
            base.elementToBeDecorated.Draw(visitor);
        }

        public override void Update()
        {
            base.elementToBeDecorated.Update();

            //VISIT THE BASE ELEMENT, GET THE COLOR ETC
            
            var mouseAdapter = new MonoGameMouse();
            var mousePositionOption = mouseAdapter.getClick();

            mousePositionOption.Visit(() => {},
                mousePosition =>
                {
                    if (is_intersecting(mousePosition))
                    {
                        onClickAction();
                    }
                });
        }
        
        
        private bool is_intersecting(Point mousePosition)
        {
            return mousePosition.X > this.position.X 
                   && mousePosition.Y > this.position.Y 
                   && mousePosition.X < this.position.X + this.width 
                   && mousePosition.Y < this.position.Y + this.height;
        }
    }
}
