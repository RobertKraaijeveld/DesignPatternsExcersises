using System;
using GUIapp.FrameworkAdapter;


namespace GUIapp
{
    public class DefaultUpdateVisitor : IUpdateVisitor
    {
        private IInputAdapter inputAdapter;

        public DefaultUpdateVisitor(IInputAdapter inputAdapter)
        {
            this.inputAdapter = inputAdapter;
        }

        //what to do with deltatime?
        public void UpdateButton(Button element, float dt)
        {
            var mousePositionOption = inputAdapter.getClick();

            mousePositionOption.Visit(() => element.color = new MonoGameColor(MyColor.Black),
                mousePosition =>
                {
                    if (element.is_intersecting(mousePosition))
                    {
                        element.color = new MonoGameColor(MyColor.Red);
                        element.action();
                    }
                });
        }

        public void UpdateLabel(Label element, float dt)
        {
            //Console.WriteLine("Updating label");
        }

        public void UpdateGuiView(GuiView gui_view, float dt)
        {
            gui_view.elements.Reset();

            //Continue if visit is true, which is done when getNext returns a some, meaning there are elementsLeft
            while (gui_view.elements.GetNext().Visit(() => false, _ => true))
            {
                //First arg is onNone, second arg is onSome
                gui_view.elements.GetCurrent().Visit(() => { }, item => { item.Update(this, dt); });
            }
        }
    }
}