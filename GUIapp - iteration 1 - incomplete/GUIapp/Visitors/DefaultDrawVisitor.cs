using GUIapp.FrameworkAdapter;

namespace GUIapp
{
    public class DefaultDrawVisitor : IDrawVisitor
    {
        private IDrawingAdapter drawingAdapter;

        public DefaultDrawVisitor(IDrawingAdapter drawingAdapter)
        {
            this.drawingAdapter = drawingAdapter;
        }

        public void DrawButton(Button element)
        {
            drawingAdapter.DrawRectangle(element.top_left_corner, element.width, element.height, element.color);
            element.label.Draw(this);
        }

        public void DrawLabel(Label element)
        {
            drawingAdapter.DrawString(element.content, element.top_left_corner, element.color);

        }

        public void DrawGuiView(GuiView gui_view)
        {
            gui_view.elements.Reset();

            //Continue if visit is true, which is done when getNext returns a some, meaning there are elementsLeft
            while (gui_view.elements.GetNext().Visit(() => false, _ => true))
            {
                //First arg is onNone, second arg is onSome
                gui_view.elements.GetCurrent().Visit(() => { }, item => { item.Draw(this); });
            }
        }
    }
}