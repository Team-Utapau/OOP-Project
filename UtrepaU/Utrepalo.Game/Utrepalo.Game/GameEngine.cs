using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Utrepalo.Game.Enums;
using Utrepalo.Game.GameObjects;
using Utrepalo.Game.GameObjects.Walls;
using Utrepalo.Game.Interfaces;

namespace Utrepalo.Game
{
    using System;
    using System.Windows.Forms;
    using Bullets;
    using GameObjects.Enemies;
    using GameObjects.Resources.Items;
    using MenuItem;
    using Test;
    using Button = Buttons.Button;
    using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
    using Game = Microsoft.Xna.Framework.Game;
    using Keys = Microsoft.Xna.Framework.Input.Keys;

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
        public static Texture2D BasisWallTexture;
        public static Texture2D HealingPotionTexture;
        public static Texture2D CoinTexture;
        public static Texture2D EnemyTexture;
        public static Texture2D EnemyBulletTexture;
        public static Texture2D BoykoTexture;
        public static Texture2D BoykoBulletTexture;
        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphics;

        //Buttons
        private Texture2D buttonTexture;
        Button button;
        Button buttonExit;


        public  bool isGameOver;
        public  bool isGameWon;

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
            HealingPotionTexture = this.Content.Load<Texture2D>("images/greenPotion");
            CoinTexture = this.Content.Load<Texture2D>("images/croppedCoin");
            MapTexture = this.Content.Load<Texture2D>("images/backgroundTest");
            EnemyTexture = this.Content.Load<Texture2D>("images/enemy");
            EnemyBulletTexture = this.Content.Load<Texture2D>("images/asteroids");
            BoykoTexture = this.Content.Load<Texture2D>("images/Boyko-TheBoss");
            BoykoBulletTexture = this.Content.Load<Texture2D>("images/boyko-bullet");
            GameObjects = MapLoader.LoadMap(this.spriteBatch);
            buttonTexture = this.Content.Load<Texture2D>("images/button");

            button = new Button(buttonTexture, Font, spriteBatch, "Restart");
            buttonExit = new Button(buttonTexture, Font, spriteBatch, "Exit");

        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)|| buttonExit.clicked)
            {
                this.Exit();
            }
            if (button.clicked)
            {
                Application.Restart();
            }

            var walls = GameObjects.Where(gameObject => !(gameObject is BaseBullet)).ToList();
                var stoneWall = GameObjects.Where(c => c is StoneWall).ToList();
                var ammo = GameObjects.Where(gameObject => gameObject is BaseBullet).ToList();
                var creatures = GameObjects.Where(gameObject => gameObject is Creature).ToList();


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
                for (int i = 0; i < creatures.Count; i++)
                {
                    creatures[i].RespondToCollision(CollisionHandler.GetCollisionInfo(creatures[i]));

                }
                GameObjects.RemoveAll(x => x.State == GameObjectState.Destroyed);
                for (int i = 0; i < walls.Count; i++)
                {
                    walls[i].RespondToCollision(CollisionHandler.GetCollisionInfo(walls[i]));
                }
               
          
                for (int i = 0; i < ammo.Count; i++)
                {
                    ammo[i].RespondToCollision(CollisionHandler.GetCollisionInfo(ammo[i]));
                }

                GameObjects.RemoveAll(x => x.State == GameObjectState.Destroyed);
            
            this.IsGameOver();
            button.Location(WindowsWidth / 2 - 100, WindowsHeight / 2 - 100);
            buttonExit.Location(WindowsWidth / 2 - 100, WindowsHeight / 2);
            button.Update();
            buttonExit.Update();
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
                if (character is Player)
                {
                    var player = character as Player;
                    player.PlayerDrow(spriteBatch);
                    player.Draw(spriteBatch);
                }
                if (character is Minion)
                {
                    var creature = character as Creature;
                    creature.Draw(spriteBatch);
                }
                if (character is Boyko)
                {
                    var creature = character as Creature;
                    creature.Draw(spriteBatch);
                }

            }

            foreach (var character in bullets)
            {
                character.Draw(this.spriteBatch);
            }
            if (isGameOver)
            {
                
                this.IsMouseVisible = true;
                if (isGameWon)
                {
                    spriteBatch.DrawString(Font, "You Win!", new Vector2(500, 220), Color.Red);
                    if (!button.clicked)
                    {
                        button.Draw();
                        buttonExit.Draw();

                    }
                }
                else
                {
                    spriteBatch.DrawString(Font, "You Lose!", new Vector2(500, 220), Color.Red);

                    if (!button.clicked)
                    {
                        button.Draw();
                        buttonExit.Draw();

                    }

                }
            }
            spriteBatch.End();

            
            base.Draw(gameTime);
        }

        private void IsGameOver()
        {
            bool isPlayerAlive = GameObjects.Any(g => g is Player);
            bool areCoinsLeft = GameObjects.Any(c => c is Coin);
            if (!isPlayerAlive)
            {
                this.isGameOver = true;
                this.isGameWon = false;
            }
            if (!areCoinsLeft)
            {
                var player = GameObjects.FirstOrDefault(c => c is Player);
                if (player.Rectangle.X >= 1200)
                {
                    this.isGameOver = true;
                    this.isGameWon = true;
                }
            }
        }
    }
}

