namespace GUIapp.GuiDecorators
{
    public abstract class GuiElementDecorator : IGuiElement
    {
        protected IGuiElement elementToBeDecorated;
        
        //Bit weird, but the base instance vars ensure each element has a position and a color.
        protected GuiElementDecorator(IGuiElement elementToBeDecorated)
        {
            this.elementToBeDecorated = elementToBeDecorated;
        }

        public abstract void Draw(IElementVisitor visitor);
        public abstract void Update();
    }
}