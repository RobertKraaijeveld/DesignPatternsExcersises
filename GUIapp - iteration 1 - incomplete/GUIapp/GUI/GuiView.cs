namespace GUIapp
{
    public class GuiView : IUpdateable, IDrawable
    {
        public GUIElementsIterator elements;


        public void Draw(IDrawVisitor visitor)
        {
            visitor.DrawGuiView(this);
        }

        public void Update(IUpdateVisitor visitor, float dt)
        {
            visitor.UpdateGuiView(this, dt);
        }
    }
}