using System.Collections.Generic;

namespace GUIapp
{
    public class GUIElementsIterator : Iterator<IGuiElement>
    {
        //temp public
        public List<IGuiElement> elements;

        private int index = -1;

        public GUIElementsIterator(List<IGuiElement> elements)
        {
            this.elements = elements;
        }


        public void Reset()
        {
            this.index = -1;
        }

        //uses visitor that will return true on some, false on none.
        //basically, haphazard hasNext
        public Option<IGuiElement> GetNext()
        {
            if ((index + 1) < elements.Count)
            {
                index++;
                return GetCurrent();
            }
            else
            {
                return new None<IGuiElement>();
            }
        }

        public Option<IGuiElement> GetCurrent()
        {
            if (index == -1) { return new None<IGuiElement>(); } 
            else { return new Some<IGuiElement>(elements[index]); }

        }
    }
}