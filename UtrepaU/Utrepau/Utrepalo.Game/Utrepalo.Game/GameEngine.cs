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
    using System;
    using FuncWorks.XNA.XTiled;

    public class GameEngine : Microsoft.Xna.Framework.Game
    {
<<<<<<< HEAD
       
=======
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
>>>>>>> 07181ee7111bad5ccb447d8d72d1cce6687c834d
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
        Rectangle mapView;
        Int32 mapIdx;
        List<Map> maps;

        Color playerColor;

        double actionTimer = 0;

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
            mapView = graphics.GraphicsDevice.Viewport.Bounds;
            mapView.X = 0;
            mapView.Y = 0;

       
        }

        protected override void LoadContent()
        {
<<<<<<< HEAD
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            Map.InitObjectDrawing(graphics.GraphicsDevice);

            maps = new List<Map>();

            maps.Add(Content.Load<Map>("Map/Map"));


            mapIdx = 0;
=======
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
>>>>>>> 07181ee7111bad5ccb447d8d72d1cce6687c834d
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // sewers map needs blendstate to look correct with alphas
            if (mapIdx == 8)
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
            else
                spriteBatch.Begin();

            if (mapIdx == 11)
                DrawLayersInOrder(maps[mapIdx], spriteBatch, mapView);
            else
            {
                maps[mapIdx].Draw(spriteBatch, mapView);

                // draw object layers test
                for (int ol = 0; ol < maps[mapIdx].ObjectLayers.Count; ol++)
                    maps[mapIdx].DrawObjectLayer(spriteBatch, ol, mapView, 0);

                // draw image layers test
                for (int il = 0; il < maps[mapIdx].ImageLayers.Count; il++)
                    maps[mapIdx].DrawImageLayer(spriteBatch, il, mapView, 0);
            }

<<<<<<< HEAD
            // draw player
            
=======
            
            //tradeMark.Append(string.Format("© {0} UTAPAU GAMES", DateTime.Now.Year));
            spriteBatch.DrawString(Font, "UTAPAU GAMES", new Vector2(0, 250), Color.Brown);

            spriteBatch.Draw(this.ball, Vector2.Zero, Color.Brown);
            for (int i = 0; i < 32; i++)
            {
                spriteBatch.Draw(this.ball, new Vector2(i * 32, 0), Color.Brown);
            }
>>>>>>> 07181ee7111bad5ccb447d8d72d1cce6687c834d

            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void DrawLayersInOrder(Map map, SpriteBatch spriteBatch, Rectangle viewport)
        {
            float layerDepth = 1.0f;
            float layerDepthDec = 1.0f / (float)map.LayerOrder.Length;

            foreach (var layer in map.LayerOrder)
            {
                switch (layer.LayerType)
                {
                    case LayerType.TileLayer:
                        map.DrawLayer(spriteBatch, layer.ID, viewport, layerDepth);
                        break;

                    case LayerType.ObjectLayer:
                        map.DrawObjectLayer(spriteBatch, layer.ID, viewport, layerDepth);
                        break;

                    case LayerType.ImageLayer:
                        map.DrawImageLayer(spriteBatch, layer.ID, viewport, layerDepth);
                        break;
                }

                layerDepth -= layerDepthDec;
            }
        }
    }
}

