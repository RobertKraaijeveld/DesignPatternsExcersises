using GUIapp.FrameworkAdapter;
using GUIapp.GuiDecorators;

namespace GUIapp
{
    public class DefaultDrawVisitor : IElementVisitor
    {
        private IDrawingAdapter drawingAdapter;

        public DefaultDrawVisitor(IDrawingAdapter drawingAdapter)
        {
            this.drawingAdapter = drawingAdapter;
        }
        

        public override void OnLabel(LabelElement element)
        {
            drawingAdapter.DrawString(element.text, element.position, element.color);
        }

        public override void OnView(ViewElement gui_view)
        {
            gui_view.elements.Reset();

            //Continue if visit is true, which is done when getNext returns a some, meaning there are elementsLeft
            while (gui_view.elements.GetNext().Visit(() => false, _ => true))
            {
                gui_view.elements.GetCurrent().Visit(() => { }, item => { item.Draw(this); });
            }
        }
    }
}