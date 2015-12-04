using System.Collections.Generic;
using System.Linq;
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

        SpriteBatch spriteBatch;
        public const int Offset = 25;
        public const int WindowsHeight = 700;
        public const int WindowsWidth = 845;
        public static List<GameObject> GameObjects = new List<GameObject>();
        GraphicsDeviceManager graphics;
        Rectangle mapView;
        Int32 mapIdx;
        List<Map> maps;
        Texture2D playerSprite;
        Rectangle sourceRect;
        Rectangle destRect;
        float elapsed;
        float delay = 200;
        private int frames = 0;
        double actionTimer = 0;

         PlayerCharacter player;

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
            destRect = new Rectangle(0, 0, 44, 46);
            player = new PlayerCharacter(playerSprite, destRect, spriteBatch, "Gosho", 2);
            base.Initialize();
            mapView = graphics.GraphicsDevice.Viewport.Bounds;
            mapView.X = 0;
            mapView.Y = 0;
            mapView.Height = WindowsHeight + 290;
            mapView.Width = WindowsWidth;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            Map.InitObjectDrawing(graphics.GraphicsDevice);

            maps = new List<Map>();

            maps.Add(Content.Load<Map>("Map/NewMap"));
            player.ObjTexture = Content.Load<Texture2D>("images/walkingDownSprite");


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
            
            sourceRect = new Rectangle(48 * frames, 0, 44, 46);
            KeyboardState keys = Keyboard.GetState();

            if (keys.IsKeyDown(Keys.Escape))
                this.Exit();

            Rectangle delta = mapView;
            if (keys.IsKeyDown(Keys.Down))
            {
                delta.Y += 1;
                MoveSprite(gameTime);
               player.MoveDown(this.Content);
            }

            if (keys.IsKeyDown(Keys.Up))
            {
                delta.Y -= 1;
                MoveSprite(gameTime);
                player.MoveUp(this.Content);
            }

            if (keys.IsKeyDown(Keys.Right))
            {
                MoveSprite(gameTime);
                player.MoveRight(this.Content);
                delta.X += 1;
            }
            if (keys.IsKeyDown(Keys.Left))
            {
                MoveSprite(gameTime);
                player.MoveLeft(this.Content);
                delta.X -= 1;
            }
            if (keys.GetPressedKeys().Count() == 0)
            {
                frames = 0;
            }


            if (maps[mapIdx].Bounds.Contains(delta))
            {

                destRect.X += delta.X - mapView.X;
                destRect.Y += delta.Y - mapView.Y;
                mapView.X = delta.X;
                mapView.Y = delta.Y;
            }
            base.Update(gameTime);
        }

        private void MoveSprite(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                if (frames >= 7)
                {
                    frames = 0;
                }
                else
                {
                    frames++;
                }
                elapsed = 0;
            }
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

            spriteBatch.Draw(player.ObjTexture, destRect, sourceRect, Color.White);
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

