using GUIapp.GuiDecorators;

namespace GUIapp
{
    public abstract class IElementVisitor
    {
        public abstract void OnLabel(LabelElement element);
        public abstract void OnView(ViewElement element);
    }
}