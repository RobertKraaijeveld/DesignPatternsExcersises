namespace GUIapp.GuiDecorators
{
    public abstract class GuiElementDecorator : IGuiElement
    {
        protected IGuiElement elementToBeDecorated;
        
        protected GuiElementDecorator(IGuiElement elementToBeDecorated)
        {
            this.elementToBeDecorated = elementToBeDecorated;
        }

        public abstract void Draw(IElementVisitor visitor);
        public abstract void Update();
    }
}