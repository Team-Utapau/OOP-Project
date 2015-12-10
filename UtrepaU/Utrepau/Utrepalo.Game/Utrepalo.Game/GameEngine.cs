using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Utrepalo.Game.GameObjects;
using Utrepalo.Game.GameObjects.Buttons;
using Utrepalo.Game.Interfaces;
using Utrepalo.Game.MenuItem;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Utrepalo.Game
{
    using System;
    using FuncWorks.XNA.XTiled;
    using Bullets;

    public class GameEngine : Microsoft.Xna.Framework.Game
    {

        SpriteBatch spriteBatch;
        public const int Offset = 25;
        public const int WindowsHeight = 700;
        public const int WindowsWidth = 845;
        public static List<GameObject> GameObjects = new List<GameObject>();
        GraphicsDeviceManager graphics;
        Rectangle mapView;
        Int32 mapIdx;
        List<Map> maps;
        

        float elapsed;
        
        int frames = 0;
        public double actionTimer = 0;

        //Button
        ExitButton exitButton;
        Texture2D exitButtonTexture;
        Rectangle exitButtonRect;

        private Rectangle exitButtonSourceRect;


        //Player
        PlayerCharacter player;
        Texture2D playerTexture;
         Rectangle drowingPlayerRectangle;
         Rectangle sourcePlayerRectangle;

        //Creature
         private Creature creature;
        private Texture2D creatureTexture;
         Rectangle drawingCreatureRectangle;
         Rectangle sourceCreatureRectangle;

        private float delay = 200;

        public GameEngine(IController controller)
            : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferHeight = WindowsHeight;
            this.graphics.PreferredBackBufferWidth = WindowsWidth;
        }

        protected override void Initialize()
        {
            player = new PlayerCharacter(playerTexture,drowingPlayerRectangle,sourcePlayerRectangle,spriteBatch,this);
            creature = new Creature(creatureTexture,drawingCreatureRectangle,sourceCreatureRectangle,spriteBatch,100,100,100,this);


            mapView = graphics.GraphicsDevice.Viewport.Bounds;
            mapView.X = 0;
            mapView.Y = 0;
            mapView.Height = WindowsHeight + 290;
            mapView.Width = WindowsWidth;

           // exitButtonRect = new Rectangle(700, 600, 100, 100);
            exitButton = new ExitButton(exitButtonTexture,exitButtonSourceRect, spriteBatch,this);
             this.IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            Map.InitObjectDrawing(graphics.GraphicsDevice);

            maps = new List<Map>();
            maps.Add(Content.Load<Map>("Map/NewMap"));
            creature.LoadContent(Content);
            player.LoadContent(Content);
            exitButton.LoadContent(Content);
          //  exitButton.ObjTexture = Content.Load<Texture2D>("images/exit-button2");

            mapIdx = 0;
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

            KeyboardState keys = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();


            if (keys.IsKeyDown(Keys.Escape))
                this.Exit();

            player.Update(gameTime);
            creature.Update(gameTime);

            Rectangle delta = mapView;

            if (keys.IsKeyDown(Keys.Down))
            {
                delta.Y += 1;
                player.MoveSprite(gameTime);
                player.MoveDown(this.Content);
            }

            if (keys.IsKeyDown(Keys.Up))
            {
                delta.Y -= 1;
                player.MoveSprite(gameTime);
                player.MoveUp(this.Content);
            }

            if (keys.IsKeyDown(Keys.Right))
            {
                delta.X += 1;
                player.MoveSprite(gameTime);
                player.MoveRight(this.Content);
            }

            if (keys.IsKeyDown(Keys.Left))
            {
                delta.X -= 1;
                player.MoveSprite(gameTime);
                player.MoveLeft(this.Content);
            }
               
                if (maps[mapIdx].Bounds.Contains(delta))
                {
                    player.position.X += delta.X - mapView.X;
                    player.position.Y += delta.Y - mapView.Y;
                    mapView.X = delta.X;
                    mapView.Y = delta.Y;
                }


                //exitButtonSourceRect = new Rectangle(0, 0, 100, 100);
                exitButton.Update(gameTime);
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

            if (mapIdx == 10)
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


            spriteBatch.End();
            spriteBatch.Begin();
            creature.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
            spriteBatch.Begin();
            exitButton.Draw(spriteBatch);
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

