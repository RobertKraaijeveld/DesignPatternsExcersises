namespace GUIapp.FrameworkAdapter
{
    public interface IDrawingAdapter
    {
        void DrawRectangle(Point topLeft, int width, int height, MonoGameColor colorAdapter);
        void DrawString(string text, Point position, MonoGameColor colorAdapter);
    }
}