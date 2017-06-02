using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using GUIapp.FrameworkAdapter;
using GUIapp.GuiDecorators;

namespace GUIapp.GuiFactories
{
    public class FancyGuiFactory : GuiFactory
    {
        private System.Action exitFunc;

        public FancyGuiFactory(System.Action exitFunc)
        {
            this.exitFunc = exitFunc;
        }
        
        
        public override ViewElement CreateMainView()
        {
            ViewElement newView = new ViewElement();
            var elementsList = new List<IGuiElement>();

            var firstBtnPosition = new Point(0, 100);
            var firstBtnColor = new MonoGameColor(MyColor.AliceBlue);
            var firstBtnText = "Clicketh thou mouse pointer here to bombard \n Thine eyes with quotes";
            System.Action firstBtnOnClickAction = () => { GuiManager.currentView = this.CreateLabelView(); };
                
            elementsList.Add(new ClickableDecorator(new LabelElement(firstBtnPosition, firstBtnColor, firstBtnText),
                                                    firstBtnOnClickAction, firstBtnPosition, 500, 30));
            
            
            var exitBtnPosition = new Point(0, 300);
            var exitBtnColor = new MonoGameColor(MyColor.AliceBlue);
            var exitBtnText = "Clicketh thou mouse pointer here to leave";
            System.Action exitBtnOnClickAction = () => { exitFunc(); };
                
            elementsList.Add(new ClickableDecorator(new LabelElement(exitBtnPosition, exitBtnColor, exitBtnText),
                                                    exitBtnOnClickAction, exitBtnPosition, 500, 30));

            
            newView.elements = new GUIElementsIterator(elementsList);
            return newView;
        }

        public override ViewElement CreateLabelView()
        {
            ViewElement newView = new ViewElement();
            var elementsList = new List<IGuiElement>();

            
            var firstLabelPosition = new Point(0, 100);
            var firstLabelColor = new MonoGameColor(MyColor.AliceBlue);
            var firstLabelText = "I returned, and saw under the sun, that the race is not to the swift, \n" +
                                 "nor the battle to the strong, neither yet bread to the wise, \n" +
                                 "nor yet riches to men of understanding, nor yet favour to men of skill; \n" +
                                 "but time and chance happeneth to them all. \n";
                
            elementsList.Add(new LabelElement(firstLabelPosition, firstLabelColor, firstLabelText));
            
            
            var backBtnPosition = new Point(0, 200);
            var backBtnColor = new MonoGameColor(MyColor.AliceBlue);
            var backBtnText = "Clicketh thou mouse pointer here to return from whence thy came";
            System.Action backBtnOnClickAction = () => { GuiManager.currentView = this.CreateMainView(); };
                
            elementsList.Add(new ClickableDecorator(new LabelElement(backBtnPosition, backBtnColor, backBtnText),
                backBtnOnClickAction, backBtnPosition, 500, 30));

            
            newView.elements = new GUIElementsIterator(elementsList);
            return newView;
        }
    }
}