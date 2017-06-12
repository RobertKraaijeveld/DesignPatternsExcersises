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

        //Drawing is always the same, so this just uses the visitor and is not decorated
        public override void Draw(IElementVisitor visitor)
        {
            base.elementToBeDecorated.Draw(visitor);
        }

        public override void Update()
        {
            base.elementToBeDecorated.Update();

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
