using CIS580GameProject6.Physics.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CIS580GameProject6
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public ParticleEngine particleEngine;
        public PhysicsRectangle floor;

        TankPlayer testTank;

        Texture2D debugTexture;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            particleEngine = new ParticleEngine();
            floor = new PhysicsRectangle(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height), GraphicsDevice.Viewport.Width, 50);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            particleEngine.LoadContent(GraphicsDevice, Content);
            debugTexture = Content.Load<Texture2D>("Pixel");

            testTank = new TankPlayer(this, new PhysicsRectangle(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 50 / 2), 50, 50));
            testTank.texture = debugTexture;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            particleEngine.Update(gameTime);
            testTank.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            testTank.Draw(spriteBatch);
            spriteBatch.Draw(debugTexture, floor, Color.Black);

            spriteBatch.End();

            // TODO: Add your drawing code here
            particleEngine.Draw();

            base.Draw(gameTime);
        }
    }
}
