using System;

namespace GUIapp
{
    public interface IUpdateable
    {
        void Update(IUpdateVisitor visitor, float dt);
    }
}