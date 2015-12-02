using System.Collections.Generic;
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
        private IController controller;
        public static List<GameObject> GameObjects = new List<GameObject>();
        GraphicsDeviceManager graphics;
        Rectangle mapView;
        Int32 mapIdx;
        List<Map> maps;
        Rectangle player;
        Texture2D playerSprite;

        double actionTimer = 0;

        public GameEngine(IController controller)
            : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.controller = controller;
            Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferHeight = WindowsHeight;
            this.graphics.PreferredBackBufferWidth = WindowsWidth;
        }

        protected override void Initialize()
        {
            base.Initialize();
            mapView = graphics.GraphicsDevice.Viewport.Bounds;
            mapView.X = 0;
            mapView.Y = 0;
            mapView.Height = WindowsHeight + 290;
            mapView.Width = WindowsWidth;

            player = maps[mapIdx].SourceTiles[0].Source;


        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            Map.InitObjectDrawing(graphics.GraphicsDevice);

            maps = new List<Map>();

            maps.Add(Content.Load<Map>("Map/NewMap"));
            playerSprite = Content.Load<Texture2D>("images/dot");


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

            if (keys.IsKeyDown(Keys.Escape))
                this.Exit();

            Rectangle delta = mapView;
            if (keys.IsKeyDown(Keys.Down))
                delta.Y +=1;
            if (keys.IsKeyDown(Keys.Up))
                delta.Y -= 1;
            if (keys.IsKeyDown(Keys.Right))
                delta.X += 1;
            if (keys.IsKeyDown(Keys.Left))
                delta.X -= 1;

            if (maps[mapIdx].Bounds.Contains(delta))
            {

                player.X += delta.X - mapView.X;
                player.Y += delta.Y - mapView.Y;
                mapView.X = delta.X;
                mapView.Y = delta.Y;
            }

          

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
            spriteBatch.Draw(playerSprite, player, Color.White);
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

