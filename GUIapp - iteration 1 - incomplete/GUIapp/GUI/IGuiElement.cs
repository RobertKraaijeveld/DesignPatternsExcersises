namespace GUIapp
{
    public interface IGuiElement
    {
        void Draw(IElementVisitor visitor);
        void Update();    
    }
}