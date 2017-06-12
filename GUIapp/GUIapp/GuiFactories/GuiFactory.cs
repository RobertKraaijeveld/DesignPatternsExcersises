namespace GUIapp.GuiFactories
{
    public abstract class GuiFactory
    {
        public abstract ViewElement CreateMainView();
        public abstract ViewElement CreateLabelView();
    }
}