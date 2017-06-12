namespace GUIapp
{
    public class ViewElement : IGuiElement
    {
        public GUIElementsIterator elements;


        public void Draw(IElementVisitor visitor)
        {
            visitor.OnView(this);
        }
        
        public void Update()
        {
            elements.Reset();

            //Continue if visit is true, which is done when getNext returns a some, meaning there are elementsLeft
            while (elements.GetNext().Visit(() => false, _ => true))
            {
                //First arg is onNone, second arg is onSome
                elements.GetCurrent().Visit(() => { }, item => { item.Update(); });
            }
        }
    }
}