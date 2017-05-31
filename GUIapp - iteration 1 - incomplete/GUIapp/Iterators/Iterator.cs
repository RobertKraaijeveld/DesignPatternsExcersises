using System;

namespace GUIapp
{
    public interface Iterator<T>
    {
        Option<T> GetNext();
        
        //not sure if nice
        Some<T> GetCurrent();
        void Reset();
    }
}