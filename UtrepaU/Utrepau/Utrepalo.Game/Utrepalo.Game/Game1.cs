namespace Utrepalo.Game
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        enum BState
        {
            HOVER,
            UP,
            DOWN
        }

        private const int NUMBER_OF_BUTTONS = 2,
            login = 0,
            register = 1,
            BUTTON_HEIGHT = 100,
           BUTTON_WIDTH = 150;

        Color background_color;
        Color[] button_color = new Color[NUMBER_OF_BUTTONS];
        Rectangle[] button_rectangle = new Rectangle[NUMBER_OF_BUTTONS];
        BState[] button_state = new BState[NUMBER_OF_BUTTONS];
        Texture2D[] button_texture = new Texture2D[NUMBER_OF_BUTTONS];
        double[] button_timer = new double[NUMBER_OF_BUTTONS];

        bool mpressed, prev_mpressed = false;
        int mx, my;
        double frame_time;





        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D mainCharRight;

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
            int x = Window.ClientBounds.Width / 2 - BUTTON_WIDTH / 2;
            int y = Window.ClientBounds.Height / 2 -
                NUMBER_OF_BUTTONS / 2 * BUTTON_HEIGHT -
                (NUMBER_OF_BUTTONS % 2) * BUTTON_HEIGHT / 2;
            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {
                button_state[i] = BState.UP;
                button_color[i] = Color.White;
                button_timer[i] = 0.0;
                button_rectangle[i] = new Rectangle(x, y, BUTTON_WIDTH, BUTTON_HEIGHT);
                y += BUTTON_HEIGHT;
            }
            IsMouseVisible = true;
            background_color = Color.CornflowerBlue;

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
            //mainCharRight = Content.Load<Texture2D>("rightMainChar");
            // TODO: use this.Content to load your game content here
            button_texture[login] =
                Content.Load<Texture2D>(@"images/download");
            button_texture[register] =
                Content.Load<Texture2D>(@"images/register_now");
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(background_color);
            spriteBatch.Begin();
            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {
                spriteBatch.Draw(button_texture[i],button_rectangle[i],button_color[i]);
            }
           // spriteBatch.Draw(mainCharRight,new Rectangle(50,50,50,50),Color.White );
            // TODO: Add your drawing code here
            spriteBatch.End();;

            base.Draw(gameTime);
        }
    }
}
