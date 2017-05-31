using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GUIapp
{
    public class DefaultDrawVisitor : IDrawVisitor
    {
        SpriteBatch sprite_batch;
        ContentManager content_manager;
        Texture2D white_pixel;
        SpriteFont default_font;


        public DefaultDrawVisitor(SpriteBatch sprite_batch, ContentManager content_manager)
        {
            this.sprite_batch = sprite_batch;
            this.content_manager = content_manager;
            white_pixel = content_manager.Load<Texture2D>("white_pixel");
            default_font = content_manager.Load<SpriteFont>("arial");
        }


        public void DrawButton(Button element)
        {
            var buttonRectangle = new Rectangle((int) element.top_left_corner.X, (int) element.top_left_corner.Y,
                (int) element.width, (int) element.height);

            sprite_batch.Draw(white_pixel, buttonRectangle, element.color);
            element.label.Draw(this);
        }

        public void DrawLabel(Label element)
        {
            sprite_batch.DrawString(default_font, element.content,
                new Vector2(element.top_left_corner.X, element.top_left_corner.Y), element.color);
        }

        public void DrawGui(GuiManager gui_manager)
        {
            gui_manager.elements.Reset();

            //Continue if visit is true, which is done when getNext returns a some, meaning there are elementsLeft
            while (gui_manager.elements.GetNext().Visit(() => false, _ => true))
            {
                //First arg is onNone, second arg is onSome
                gui_manager.elements.GetCurrent().Visit(() => { }, item => { item.Draw(this); });
            }
        }
    }
}