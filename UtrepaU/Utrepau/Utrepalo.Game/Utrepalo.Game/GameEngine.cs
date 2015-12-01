using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Utrepalo.Game.GameObjects;
using Utrepalo.Game.Interfaces;

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

        // test
        Texture2D ball;

        bool mpressed, prev_mpressed = false;
        int mx, my;
        double frame_time;
        SpriteBatch spriteBatch;

        /// <summary>
        /// ////////////////////////
        /// </summary>
        public const int Offset = 25;
        public const int WindowsHeight = 600;
        public const int WindowsWidth = 1024;

        public static SpriteFont Font;

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

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.graphics.PreferredBackBufferWidth = WindowsWidth;
            this.graphics.PreferredBackBufferHeight = WindowsHeight;
            this.graphics.ApplyChanges();

            Font = this.Content.Load<SpriteFont>(@"Fonts/ArialFont");
            //this.gamePauseFont = this.Content.Load<SpriteFont>("Graphics/Fonts/GamePauseFont");
            ball = this.Content.Load<Texture2D>(@"images/ball-resize");

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

            
            //tradeMark.Append(string.Format("� {0} UTAPAU GAMES", DateTime.Now.Year));
            spriteBatch.DrawString(Font, "UTAPAU GAMES", new Vector2(0, 250), Color.Brown);

            spriteBatch.Draw(this.ball, Vector2.Zero, Color.Brown);
            for (int i = 0; i < 32; i++)
            {
                spriteBatch.Draw(this.ball, new Vector2(i * 32, 0), Color.Brown);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

