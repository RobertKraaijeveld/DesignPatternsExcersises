namespace GUIapp.FrameworkAdapter
{
    public class MonoGameDrawer : IDrawingAdapter
    {
        Microsoft.Xna.Framework.Graphics.SpriteBatch sprite_batch;
        Microsoft.Xna.Framework.Content.ContentManager content_manager;
        Microsoft.Xna.Framework.Graphics.Texture2D texture;
        Microsoft.Xna.Framework.Graphics.SpriteFont font;

        
        public MonoGameDrawer(string textureName, string fontName, Microsoft.Xna.Framework.Graphics.SpriteBatch sprite_batch,
                              Microsoft.Xna.Framework.Content.ContentManager content_manager)
        {
            this.sprite_batch = sprite_batch;
            this.content_manager = content_manager;
            this.texture = content_manager.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(textureName);
            this.font = content_manager.Load<Microsoft.Xna.Framework.Graphics.SpriteFont>(fontName);
        }

        public void DrawRectangle(Point topleft, int width, int height, MonoGameColor colorAdapter)
        {
            var rect = new Microsoft.Xna.Framework.Rectangle((int) topleft.X, (int) topleft.Y, width, height);
            sprite_batch.Draw(texture, rect, colorAdapter.toFrameworkColor());
        }
        
        public void DrawString(string text, GUIapp.Point point,  MonoGameColor colorAdapter)
        {
            var pointAsVector = new Microsoft.Xna.Framework.Vector2(point.X, point.Y);
            sprite_batch.DrawString(font, text, pointAsVector, colorAdapter.toFrameworkColor());
        }
    }
}