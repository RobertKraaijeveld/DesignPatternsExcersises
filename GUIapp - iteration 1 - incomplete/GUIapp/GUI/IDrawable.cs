using System;

namespace GUIapp
{
    public interface IDrawable 
    { 
        void Draw(IDrawVisitor visitor);
    }
}