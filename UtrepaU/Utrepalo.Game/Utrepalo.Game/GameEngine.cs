using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Utrepalo.Game.Enums;
using Utrepalo.Game.GameObjects;
using Utrepalo.Game.GameObjects.Walls;
using Utrepalo.Game.Interfaces;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Utrepalo.Game
{
    using Bullets;
    using GameObjects.Resources.Items;
    using Test;

    public class GameEngine : Microsoft.Xna.Framework.Game
    {
        public const int WindowsWidth = 1200;
        public const int WindowsHeight = 700;
        public const int Offset = 25;

        public static List<GameObject> GameObjects = new List<GameObject>(); 

        public static Texture2D BulletTexture;
        public static SpriteFont Font;

        public static Texture2D PlayerTexture;
        public static Texture2D HealthTexture;

        public static Texture2D MapTexture;
        //test
        public static Texture2D BasisWallTexture;

        public static Texture2D HealingPotionTexture;

        public static Texture2D CoinTexture;

        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphics;


        private bool isGameOver;
        private bool isGameWon;

        private IController controller;

        public GameEngine(IController controller)
            : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.controller = controller;
            this.graphics.PreferredBackBufferHeight = WindowsHeight;
            this.graphics.PreferredBackBufferWidth = WindowsWidth;
        }

        protected override void Initialize()
        {
            
            //this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.graphics.ApplyChanges();
            Font = this.Content.Load<SpriteFont>("CustomFonts/ArialFont");
            PlayerTexture = this.Content.Load<Texture2D>("images/walkingDownSprite");
            BasisWallTexture = this.Content.Load<Texture2D>("images/Wall");
            BulletTexture = this.Content.Load<Texture2D>("images/fireballSprite");
            HealthTexture = this.Content.Load<Texture2D>("images/dot");
            HealingPotionTexture = this.Content.Load<Texture2D>("images/greenPotion");
            CoinTexture = this.Content.Load<Texture2D>("images/croppedCoin");
            
            MapTexture = this.Content.Load<Texture2D>("images/backgroundTest");

            GameObjects = MapLoader.LoadMap(this.spriteBatch);

        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            
            if (true)
            {
                var walls = GameObjects.Where(gameObject => !(gameObject is BaseBullet) && !(gameObject is CollectibleItem)).ToList();
                var stoneWall = GameObjects.Where(c => c is StoneWall).ToList();
                var collectibles = GameObjects.Where(gameObject => gameObject is CollectibleItem).ToList();
                var ammo = GameObjects.Where(gameObject => gameObject is BaseBullet).ToList();

              

                for (int i = 0; i < GameObjects.Count; i++)
                {
                    if (GameObjects[i] is Player)
                    {
                        var player = GameObjects[i] as Player;
                        var wallRectangle = walls.FirstOrDefault(w => w.Rectangle.Intersects(player.Rectangle)).Rectangle;

                        player.PlayerUpdate(gameTime, this.Content, wallRectangle);
                    
                    }
                   
                    GameObjects[i].Update();
                }

                for (int i = 0; i < walls.Count; i++)
                {
                    walls[i].RespondToCollision(CollisionHandler.GetCollisionInfo(walls[i]));
                }
                for (int i = 0; i < stoneWall.Count; i++)
                {
                    if (stoneWall[i]!=null)
                    {
                     
                    }
                    
                }
              
                for (int i = 0; i < collectibles.Count; i++)
                {
                    collectibles[i].RespondToCollision(CollisionHandler.GetCollisionInfo(collectibles[i]));
                }

                for (int i = 0; i < ammo.Count; i++)
                {
                    ammo[i].RespondToCollision(CollisionHandler.GetCollisionInfo(ammo[i]));
                }

                GameObjects.RemoveAll(x => x.State == GameObjectState.Destroyed);
            }
            base.Update(gameTime);

            this.controller.ProcessUserInput();
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.DarkGoldenrod);
            this.spriteBatch.Begin();
            spriteBatch.Draw(MapTexture, new Rectangle(0, 0, 1600, WindowsHeight), new Rectangle(0, 0, 1400, WindowsHeight), Color.White);
            var characters = GameObjects.Where(gameObject => gameObject is Character);
            var walls = GameObjects.Where(gameObject => gameObject is Wall);
            var bullets = GameObjects.Where(gameObject => gameObject is BaseBullet);
            var healingPotions = GameObjects.Where(c => c is HealingPotion).ToList();
            var coins = GameObjects.Where(c => c is Coin).ToList();
           

            foreach (var character in walls)
            {
                character.Draw(this.spriteBatch);
            }
            foreach (var healingPotion in healingPotions)
            {
                healingPotion.Draw(this.spriteBatch);
                
            }
            foreach (var coin in coins)
            {
                coin.Draw(this.spriteBatch);

            }
            foreach (var character in characters)
            {
                var player = character as Player;
                player.PlayerDrow(spriteBatch);
                player.Draw(spriteBatch);
            }

            foreach (var character in bullets)
            {
                character.Draw(this.spriteBatch);
            }
            spriteBatch.End();
        
            
            
            base.Draw(gameTime);
        }


    }
}

