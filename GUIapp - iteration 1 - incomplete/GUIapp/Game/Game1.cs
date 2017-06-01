using System;
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

        IInputAdapter inputAdapter;
        IDrawingAdapter drawingAdapter;

        IDrawVisitor DrawVisitor;
        IUpdateVisitor UpdateVisitor;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
            this.IsMouseVisible = true;
            
            GuiFactory guiFactory = new FancyGuiFactory(() => Exit());
            GuiManager.currentView = guiFactory.CreateMainView();
            
            inputAdapter = new MonoGameMouse();
            UpdateVisitor = new DefaultUpdateVisitor(inputAdapter );
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            drawingAdapter = new MonoGameDrawer("white_pixel", "arial", spriteBatch, Content);
            DrawVisitor = new DefaultDrawVisitor(drawingAdapter);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GuiManager.currentView.Update(UpdateVisitor, (float) gameTime.ElapsedGameTime.TotalMilliseconds);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();
            GuiManager.currentView.Draw(DrawVisitor);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}