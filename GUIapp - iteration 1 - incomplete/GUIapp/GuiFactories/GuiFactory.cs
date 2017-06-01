namespace GUIapp.GuiFactories
{
    public abstract class GuiFactory
    {
        public abstract GuiView CreateMainView();
        public abstract GuiView CreateInputView();
        public abstract GuiView CreateLabelView();
    }
}