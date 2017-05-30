using System;

namespace GUIapp
{
    //Marker interfaces are an anti-pattern
    public interface GuiElement : IDrawable, IUpdateable { }
}