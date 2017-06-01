namespace GUIapp.FrameworkAdapter
{
    public enum MyColor
    {
        White,
        Black,
        Red,
        Blue,
        AliceBlue
    };
    
    public class MonoGameColor
    {
        public MyColor mycolor;
            
        public MonoGameColor(MyColor mycolor)
        {
            this.mycolor = mycolor;
        }

        
        public Microsoft.Xna.Framework.Color toFrameworkColor()
        {
            switch (mycolor)
            {
                case MyColor.White:
                    return Microsoft.Xna.Framework.Color.White;
                case MyColor.Black:
                    return Microsoft.Xna.Framework.Color.Black;
                case MyColor.Red:
                    return Microsoft.Xna.Framework.Color.Red;
                case MyColor.Blue:
                    return Microsoft.Xna.Framework.Color.Blue;
                case MyColor.AliceBlue:
                    return Microsoft.Xna.Framework.Color.AliceBlue;
                default:
                    return Microsoft.Xna.Framework.Color.White;
                
            }
        }
    }
}