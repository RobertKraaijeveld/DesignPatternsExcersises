using System;

namespace GUIapp
{
    public interface IDrawVisitor 
    {
        void DrawButton(Button element);
        void DrawLabel(Label element);
        void DrawGui(GuiManager element);
    }
}