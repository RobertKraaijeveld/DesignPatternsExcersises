using System;

namespace GUIapp
{
    public interface IUpdateVisitor 
    {
        void UpdateButton(Button element, float dt);
        void UpdateLabel(Label element, float dt);
        void UpdateGui(GuiManager element, float dt);
    }
}