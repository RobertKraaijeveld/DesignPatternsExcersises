using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using GUIapp.FrameworkAdapter;

namespace GUIapp.GuiFactories
{
    //RETURN A GUI ITERATOR INSTEAD
    public class FancyGuiFactory : GuiFactory
    {
        private System.Action exitFunc;

        public FancyGuiFactory(System.Action exitFunc)
        {
            this.exitFunc = exitFunc;
        }
        
        
        public override GuiView CreateMainView()
        {
            GuiView newView = new GuiView();
            var elementsList = new List<GuiElement>();


            elementsList.Add(new Button("Clicketh thou mouse pointer here to bombard \n Thine eyes with inputs" ,
                             new Point(0, 100), 30, new MonoGameColor(MyColor.AliceBlue), 500, 30, () => { GuiManager.currentView = this.CreateInputView(); }));
            
            elementsList.Add(new Button("Clicketh thou mouse pointer here to bombard \n Thine eyes with quoths" ,
                             new Point(0, 150), 30, new MonoGameColor(MyColor.AliceBlue), 500, 30, () => { GuiManager.currentView = this.CreateLabelView(); }));

            elementsList.Add(new Button("Clicketh thou mouse pointer here to leave this lowly program",
                new Point(0, 200), 30, new MonoGameColor(MyColor.AliceBlue), 500, 30, () => { exitFunc(); }));
            
            
            newView.elements = new GUIElementsIterator(elementsList);
            return newView;
        }

        public override GuiView CreateInputView()
        {
            GuiView newView = new GuiView();
            var elementsList = new List<GuiElement>();

            
            elementsList.Add(new Label("Behold, a stately input screen of the saintly days of yore",
                             new Point(0, 0), 10, new MonoGameColor(MyColor.Black)));
            
            elementsList.Add(new Button("Clicketh thou mouse pointer here return to where thee came from",
                             new Point(0, 100), 30, new MonoGameColor(MyColor.AliceBlue), 500, 30, () => { GuiManager.currentView = this.CreateMainView(); }));

            
            newView.elements = new GUIElementsIterator(elementsList);
            return newView;
        }

        public override GuiView CreateLabelView()
        {
            GuiView newView = new GuiView();
            var elementsList = new List<GuiElement>();

            elementsList.Add(new Label("I returned, and saw under the sun, that the race is not to the swift, \n" +
                                       "nor the battle to the strong, neither yet bread to the wise, \n" +
                                       "nor yet riches to men of understanding, nor yet favour to men of skill; \n" +
                                       "but time and chance happeneth to them all. \n",
                new Point(0, 0), 10, new MonoGameColor(MyColor.Black)));
            
            elementsList.Add(new Button("Clicketh thou mouse pointer here return to where thee came from",
                new Point(0, 100), 30, new MonoGameColor(MyColor.AliceBlue), 500, 30, () => { GuiManager.currentView = this.CreateMainView(); }));

            
            newView.elements = new GUIElementsIterator(elementsList);
            return newView;
        }
    }
}