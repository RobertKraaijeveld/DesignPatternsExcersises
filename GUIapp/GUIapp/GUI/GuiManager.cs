namespace GUIapp
{
    //This ensures we never update the elements of the wrong view, 
    //since only 1 view can be active at the same time
    public static class GuiManager
    {
        public static ViewElement currentView;
    }
}