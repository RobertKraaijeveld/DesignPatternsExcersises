using GUIapp.FrameworkAdapter;

namespace GUIapp.GuiDecorators
{
    public class LabelElement : IGuiElement
    {
        public Point position;
        public MonoGameColor color;
        public string text;

        public LabelElement(Point position, MonoGameColor color, string text)
        {
            this.position = position;
            this.color = color;
            this.text = text;
        }

        public void Draw(IElementVisitor visitor)
        {
            visitor.OnLabel(this);
        }

        public void Update()
        {
            //Nothing to update here, decorator will do that
        }
    }
}