using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Utrepalo.Game
{
    public class GameEngine : Microsoft.Xna.Framework.Game
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
        SpriteBatch spriteBatch;

        /// <summary>
        /// ////////////////////////
        /// </summary>
        public const int Offset = 25;
        public const int WindowsHeight = 400;
        public const int WindowsWidth = 400;
        private IController controller;
        public static List<GameObject> GameObjects = new List<GameObject>();
        GraphicsDeviceManager graphics;
        public GameEngine(IController controller)
            : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.controller = controller;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

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
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(background_color);
            spriteBatch.Begin();
            for (int i = 0; i < NUMBER_OF_BUTTONS; i++)
            {
                spriteBatch.Draw(button_texture[i], button_rectangle[i], button_color[i]);
            }
            // spriteBatch.Draw(mainCharRight,new Rectangle(50,50,50,50),Color.White );
            // TODO: Add your drawing code here
            spriteBatch.End(); ;

            base.Draw(gameTime);
        }
    }
}

