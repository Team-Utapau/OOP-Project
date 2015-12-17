using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.Enums;
using Utrepalo.Game.GameObjects.Resources.Items;

namespace Utrepalo.Game.GameObjects
{
    using System.Collections.Generic;
    using Bullets;
    using Microsoft.Xna.Framework.Input;
    using Game = Microsoft.Xna.Framework.Game;

    public class Player : PlayerCharacter
    {
        private const int DefaultAttack = 200;
        private const int DefaultHealthPoints = 500;
        private const double DefaultSpeed = 3;
        private float elapsed;
        private int frame = 0;
        private double delay = 200;
        private Rectangle sourceRectangle;


        public Player(Texture2D objTexture, Rectangle rectangle) : base(objTexture, rectangle, DefaultAttack, DefaultHealthPoints)
        {
            this.Direction = Direction.Down;
            this.Speed = DefaultSpeed;
            this.IsVisible = true;
        }

      

        public double BaseSpeed { get; set; }

        public bool IsVisible { get; set; }


        public override void Move()
        {
           
        }

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Space) && !this.HasShot)
            {
                this.Shoot(this.Direction);
                this.HasShot = true;
            }
            else if (state.IsKeyUp(Keys.Space))
            {
                this.HasShot = false;
            }

            base.Update();
        }
        
        public void PlayerUpdate(GameTime gameTime, ContentManager content, Rectangle wallRec)
        {
            KeyboardState state = Keyboard.GetState();
            this.Update();
            this.sourceRectangle = new Rectangle(48 * frame, 0, 44, 46);
            Rectangle checkPostion;


            if (state.IsKeyDown(Keys.Up))
            {
                this.Direction = Direction.Up;
                this.Speed = this.Speed;
                this.MoveSprite(gameTime);
                this.MoveUp(content);
                checkPostion = this.rectangle;
                checkPostion.Y -= 2;
                if (wallRec != null && checkPostion != wallRec)
                {
                    this.rectangle.Y -= 2;
                }
            }
             if (state.IsKeyDown(Keys.Down))
            {
                this.Direction = Direction.Down;
                this.Speed = this.Speed;
                this.MoveSprite(gameTime);
                this.MoveDown(content);
                rectangle.Y += 2;

            }
            if (state.IsKeyDown(Keys.Left))
            {
                this.Direction = Direction.Left;
                this.Speed = this.Speed;
                this.MoveSprite(gameTime);
                this.MoveLeft(content);
                rectangle.X -= 2;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                this.Direction = Direction.Right;
                this.Speed = this.Speed;
                this.MoveSprite(gameTime);
                this.MoveRight(content);
                rectangle.X += 2;

            }
            else
            {
                this.Speed = 0;
            }
            this.CheckBorderCollision();
        }

        //public override void RespondToCollision(GameObject hitObject)
        //{
        //    base.RespondToCollision(hitObject);
        //    if (hitObject is CollectibleItem)
        //    {
        //        this.TryToAddItemEffect((CollectibleItem)hitObject);
        //    }
        //}

        //public void TryToAddItemEffect(CollectibleItem item)
        //{
        //    if (this.HealthPoints == DefaultHealthPoints)
        //    {
        //        return;
        //    }

        //    this.HealthPoints += item.HealthEffect;
        //    if (this.HealthPoints > DefaultHealthPoints)
        //    {
        //        this.HealthPoints = DefaultHealthPoints;
        //    }
        //}

        public override void Draw(SpriteBatch spriteBatch)
        {
            var coinsNeeded = 10;
            spriteBatch.DrawString(
                GameEngine.Font,
                string.Format("Health: {0}\nCoins: {1}/{2}", this.HealthPoints,this.Coins,coinsNeeded),
                new Vector2(GameEngine.WindowsWidth- 250, 21),
                Color.DarkRed);
          
        }

        public void PlayerDrow(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.objTexture, this.Rectangle, sourceRectangle, Color.White);
        }

        private void MoveSprite(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                if (frame >= 7)
                {
                    frame = 0;
                }
                else
                {
                    frame++;
                }
                elapsed = 0;
            }
        }

        private void MoveUp(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingUpSprite");
        }
        private void MoveDown(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingDownSprite");
        }
        private void MoveLeft(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingLeftSprite");
        }
        private void MoveRight(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingRightSprite");
        }
    }
}
