using System.Collections.Generic;

namespace GUIapp
{
    public class GUIElementsIterator : Iterator<GuiElement>
    {
        //temp public
        public List<GuiElement> elements;

        private int index = -1;

        public GUIElementsIterator(List<GuiElement> elements)
        {
            this.elements = elements;
        }


        public void Reset()
        {
            this.index = -1;
        }

        //uses visitor that will return true on some, false on none.
        //basically, haphazard hasNext
        public Option<GuiElement> GetNext()
        {
            if (HasNext())
            {
                MoveNext();
                return GetCurrent();
            }
            else
            {
                return new None<GuiElement>();
            }
        }

        public Some<GuiElement> GetCurrent()
        {
            return new Some<GuiElement>(elements[index]);
        }

        
        private bool HasNext()
        {
            return (index + 1) < elements.Count;
        }

        private void MoveNext()
        {
            index++;
        }
    }
}