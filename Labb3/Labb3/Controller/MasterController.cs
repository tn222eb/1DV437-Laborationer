using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Labb3.View;
using Labb3.Model;
using Labb3.View.ParticleSystem;
using Labb3.Controller;

namespace Labb3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        BallView m_ballView;
        BallSimulation m_ballSimulation;
        Camera m_camera;
        GameController m_gameController;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 400;
            graphics.PreferredBackBufferWidth = 400;
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Texture2D ballTexture = Content.Load<Texture2D>("Ball");
            Texture2D border = new Texture2D(GraphicsDevice, 1, 1);
            border.SetData(new[] { Color.White });

            this.m_camera = new Camera(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            this.m_ballSimulation = new BallSimulation();
            this.m_ballView = new BallView(m_ballSimulation, spriteBatch, ballTexture, border, m_camera);
            this.m_gameController = new GameController(m_camera, Content, m_ballSimulation);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            float timeElapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            m_gameController.Update(timeElapsedSeconds);
            m_ballSimulation.Update(timeElapsedSeconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);

            // TODO: Add your drawing code here
            m_gameController.Draw(spriteBatch);
            m_ballView.DrawBorder();
            //m_ballView.DrawBall();
            
            base.Draw(gameTime);
        }
    }
}
