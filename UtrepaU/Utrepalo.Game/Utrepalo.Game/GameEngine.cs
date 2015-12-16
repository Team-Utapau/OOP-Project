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

        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphics;
        private Camera camera;

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
            //camera = new Camera(GraphicsDevice.Viewport);
            //drowingPlayerRectangle = new Rectangle(-400, -400, 48, 50);
            //sourcePlayerRectangle = new Rectangle(0, 0, 48, 50);
            //drawingCreatureRectangle = new Rectangle(-400,-400,48,50);
            ////drowingMapRectangle = new Rectangle(0,0,1940,2048);
            ////sourceMapRectangle = new Rectangle(0, 0, 1960, 2048);
            //player = new Player(playerTexture, drowingPlayerRectangle, sourcePlayerRectangle, spriteBatch, this);
            //exitButton = new ExitButton(exitButtonTexture, exitButtonSourceRect, spriteBatch, this);
            //healingPotion = new HealingPotion(healingPotionTexture,drowingPotionRectangle,sourcePotionRectangle,spriteBatch,this);

            //creature = new Creature(creatureTexture, drawingCreatureRectangle, sourceCreatureRectangle, spriteBatch, 100, 100, 100, this);
            //////worldMap = new WorldMap(mapTexture,drowingMapRectangle,sourceMapRectangle,spriteBatch,this);


            //////mapView = graphics.GraphicsDevice.Viewport.Bounds;
            //////mapView.X = 0;
            //////mapView.Y = 0;
            //////mapView.Height = WindowsHeight + 290;
            //////mapView.Width = WindowsWidth;

            //this.IsMouseVisible = true;
            camera = new Camera(GraphicsDevice.Viewport);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.graphics.ApplyChanges();
            Font = this.Content.Load<SpriteFont>("CustomFonts/ArialFont");
            
            //BasicTankTexture = this.Content.Load<Texture2D>("Graphics/Sprites/basicTank");
            PlayerTexture = this.Content.Load<Texture2D>("images/walkingDownSprite");
            //FastTankTexture = this.Content.Load<Texture2D>("Graphics/Sprites/fastTank");
            BasisWallTexture = this.Content.Load<Texture2D>("images/Wall");
            //BasicBushTexture = this.Content.Load<Texture2D>("Graphics/Sprites/basicBush");
            BulletTexture = this.Content.Load<Texture2D>("images/bullet");
            //BunkerTexture = this.Content.Load<Texture2D>("Graphics/Sprites/turret");
            //ArmorTexture = this.Content.Load<Texture2D>("Graphics/Sprites/armorSprite");
            HealthTexture = this.Content.Load<Texture2D>("images/dot");
            //ShieldTexture = this.Content.Load<Texture2D>("Graphics/Sprites/shieldSprite");
            //SpeedPowerUpTexture = this.Content.Load<Texture2D>("Graphics/Sprites/speedPowerUpTexture");
            //SteelWallTexture = this.Content.Load<Texture2D>("Graphics/Sprites/steelWall");
            MapTexture = this.Content.Load<Texture2D>("Map/m1fpuUr");

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
            
            if (true/*!this.isGamePaused*/)
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



            this.CheckGameOver();

            base.Update(gameTime);

            this.controller.ProcessUserInput();
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.DarkGoldenrod);
            this.spriteBatch.Begin();

            var characters = GameObjects.Where(gameObject => gameObject is Character);
            var obstacles = GameObjects.Where(gameObject => gameObject is Wall/* || gameObject is Hideout*/);
            var collectibles = GameObjects
                .Where(gameObject => gameObject is CollectibleItem && ((CollectibleItem)gameObject).ItemState == CollectibleItemState.Active);
            var bullets = GameObjects.Where(gameObject => gameObject is BaseBullet);    

            foreach (var character in characters)
            {
                var player = character as Player;
                player.PlayerDrow(spriteBatch);
            }

            foreach (var character in obstacles)
            {
                character.Draw(this.spriteBatch);
            }

            foreach (var item in collectibles)
            {
                item.Draw(this.spriteBatch);
            }

            foreach (var character in bullets)
            {
                character.Draw(this.spriteBatch);
            }
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);
            
            //if (this.isGamePaused)
            //{
            //    if (this.isGameOver)
            //    {
            //        const string GameLostMessage = "You were killed! Press Enter to restart the game.";
            //        const string GameWonMessage = "All enemies are destroyed! Press Enter to restart the game.";

            //        this.spriteBatch.DrawString(
            //            Font,
            //            this.isGameWon ? GameWonMessage : GameLostMessage,
            //            new Vector2(50, WindowHeight - 100),
            //            Color.BlanchedAlmond);
            //    }
            //    else
            //    {
            //        this.spriteBatch.DrawString(
            //            this.gamePauseFont,
            //            "Paused",
            //            new Vector2(WindowWidth / 3, WindowHeight / 3),
            //            Color.BlanchedAlmond);
            //    }
            //}

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        private void CheckGameOver()
        {
            //bool enemiesLeft = GameObjects.Any(gameObject => gameObject is EnemyTank || gameObject is Bunker);
            bool playerAlive = GameObjects.Any(gameObject => gameObject is Player);

            //if (!enemiesLeft)
            //{
            //    this.isGameOver = true;
            //    this.isGameWon = true;
            //}
            //else if (!playerAlive)
            //{
            //    this.isGameOver = true;
            //    this.isGameWon = false;
            //}
        }

    }
}

