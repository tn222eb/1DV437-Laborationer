using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _1DV437_Labb1_Uppgift4.Model;
using _1DV437_Labb1_Uppgift4.View;

namespace _1DV437_Labb1_Uppgift4
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MasterController : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BallView m_ballView;
        BallSimulation m_ballSimulation;
        private int m_height = 800;
        private int m_width = 400;

        public MasterController()
            : base()
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D backgroundTexture = Content.Load<Texture2D>("Background");
            Texture2D ballTexture = Content.Load<Texture2D>("Ball");
            Texture2D border = new Texture2D(GraphicsDevice, 1, 1);
            border.SetData(new[] { Color.White });

    
            this.m_ballSimulation = new BallSimulation();
            this.m_ballView = new BallView(m_ballSimulation, spriteBatch, backgroundTexture, ballTexture, border, m_height, m_width);
            // TODO: use this.Content to load your game content here
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
            m_ballSimulation.Update(timeElapsedSeconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            m_ballView.DrawLevel();
            m_ballView.DrawBall();

            base.Draw(gameTime);
        }
    }
}
