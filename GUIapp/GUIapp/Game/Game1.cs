using GUIapp.FrameworkAdapter;
using GUIapp.GuiFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GUIapp
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        IDrawingAdapter drawingAdapter;
        IElementVisitor drawingVisitor;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
            this.IsMouseVisible = true;
            
            drawingVisitor = new DefaultDrawVisitor(drawingAdapter);
            
            GuiFactory guiFactory = new FancyGuiFactory(() => Exit());
            GuiManager.currentView = guiFactory.CreateMainView();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            drawingAdapter = new MonoGameDrawer("white_pixel", "arial", spriteBatch, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GuiManager.currentView.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();
            GuiManager.currentView.Draw(drawingVisitor);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}