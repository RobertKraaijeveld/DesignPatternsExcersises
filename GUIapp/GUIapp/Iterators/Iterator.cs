using System;

namespace GUIapp
{
    public interface Iterator<T>
    {
        Option<T> GetNext();
        Option<T> GetCurrent();
        void Reset();
    }
}