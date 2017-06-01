using Microsoft.Xna.Framework.Input;

namespace GUIapp.FrameworkAdapter
{
    public class MonoGameMouse : IInputAdapter
    {
        public Option<Point> getClick()
        {
            var mouse = Microsoft.Xna.Framework.Input.Mouse.GetState();
            
            if(mouse.LeftButton == ButtonState.Pressed)
                return new Some<Point>(new Point(mouse.X, mouse.Y));
            else
                return new None<Point>();
        }
    }
}