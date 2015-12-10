using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Content;
    using Bullets;
    using Interfaces;
    using Microsoft.Xna.Framework.Input;
    using System;
    using Resources;
    using Game = Microsoft.Xna.Framework.Game;

    public class PlayerCharacter : GameObject, IEnhanceable /*: Character*/
    {

        public Texture2D bulletTexture;
        public float bulletDelay;
        public Vector2 position;
        public float elapsed;
        public double delay = 200;
        public KeyboardState oldState;
        public int frame;
        public int speed;
        private List<Bullet> bullets;
        private string lastDirection = "down";
        private bool bulletAvailable = true;
        private string bulletDirect = "down";


        private int gold;
        private int lifes;

        public PlayerCharacter(Texture2D objTexture, Rectangle drowingRectangle, Rectangle sourceRectangle, SpriteBatch spriteBatch, Game game) : base(objTexture, drowingRectangle, sourceRectangle, spriteBatch, game)
        {
            this.bullets = new List<Bullet>();
            this.speed = 2;
            this.bulletDelay = 1f;
            //this.sourceRectangle = new Rectangle();

            this.Gold = gold;
            this.Lifes = lifes;
        }

        public int Gold  { get; set; }
        public int Lifes { get; set; }

        public IEnumerable<Resource> Resources
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void LoadContent(ContentManager content)
        {
            this.bulletTexture = content.Load<Texture2D>("images/bullet");
            this.objTexture = content.Load<Texture2D>("images/walkingdownsprite");

        }

        public override void RespondToCollision(GameObject hitObject)
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objTexture, position, SourceRectangle, Color.White);
            foreach (Bullet bullet in this.bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }

        public void Shoot()
        {
            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }

            if (bulletDelay <= 0)
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X + 32 - newBullet.texture.Width / 2, position.Y + 30);
                newBullet.isVisible = true;
                bulletAvailable = false;

                if (bullets.Count < 1)  
                {

                    bullets.Add(newBullet);
                }
            }

            if (bulletDelay == 0)
            {
                bulletDelay = 1;
            }
        }

        public void Update(GameTime gameTime)
        {
            var newState = Keyboard.GetState();
            this.SourceRectangle = new Rectangle(48 * frame, 0, 44, 46);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
            {
                Shoot();
            }
            oldState = newState;

            UpdateBullets();
            if (keyState.IsKeyDown(Keys.Up) || (keyState.IsKeyDown(Keys.Up) && keyState.IsKeyDown(Keys.Space)))
            {
                position.Y = position.Y - speed;
                lastDirection = "up";
                if (bulletAvailable == true)
                {
                    bulletDirect = "up";
                    bulletAvailable = false;
                }
            }

            if (keyState.IsKeyDown(Keys.Down) || (keyState.IsKeyDown(Keys.Down) && keyState.IsKeyDown(Keys.Space)))
            {
                position.Y = position.Y + speed;
                lastDirection = "down";
                if (bulletAvailable == true)
                {
                    bulletDirect = "down";
                    bulletAvailable = false;
                }
            }

            if (keyState.IsKeyDown(Keys.Right) || (keyState.IsKeyDown(Keys.Right) && keyState.IsKeyDown(Keys.Space)))
            {
                position.X = position.X + speed;
                lastDirection = "right";
                if (bulletAvailable == true)
                {
                    bulletDirect = "right";
                    bulletAvailable = false;
                }
            }

            if (keyState.IsKeyDown(Keys.Left) || (keyState.IsKeyDown(Keys.Left) && keyState.IsKeyDown(Keys.Space)))
            {
                position.X = position.X - speed;
                lastDirection = "left";
                if (bulletAvailable == true)
                {
                    bulletDirect = "left";
                    bulletAvailable = false;
                }
            }

        }

        public void UpdateBullets()
        {
            foreach (Bullet bullet in this.bullets)
            {
                if (bulletDirect == "up")
                {
                    bullet.position.Y = bullet.position.Y - bullet.speed;
                }
                else if (bulletDirect == "down")
                {
                    bullet.position.Y = bullet.position.Y + bullet.speed;
                }
                else if (bulletDirect == "right")
                {
                    bullet.position.X = bullet.position.X + bullet.speed;
                }
                else if (bulletDirect == "left")
                {
                    bullet.position.X = bullet.position.X - bullet.speed;
                }

                if (bullet.position.Y < this.position.Y - 250)
                {
                    bullet.isVisible = false;
                    bulletAvailable = true;
                }
                if (bullet.position.X < this.position.X - 250)
                {
                    bullet.isVisible = false;
                    bulletAvailable = true;
                }
                if (bullet.position.Y > this.position.Y + 250)
                {
                    bullet.isVisible = false;
                    bulletAvailable = true;
                }
                if (bullet.position.X > this.position.X + 250)
                {
                    bullet.isVisible = false;
                    bulletAvailable = true;
                }
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].isVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        public void MoveSprite(GameTime gameTime)
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

        public void MoveUp(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingUpSprite");
            //this.bulletTexture = content.Load<Texture2D>("images/bullet");
        }

        public void MoveDown(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingDownSprite");
           // this.bulletTexture = content.Load<Texture2D>("images/bullet");
        }

        public void MoveLeft(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingLeftSprite");
            //this.bulletTexture = content.Load<Texture2D>("images/bullet");
        }

        public void MoveRight(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingRightSprite");
            //this.bulletTexture = content.Load<Texture2D>("images/bullet");
        }

        public void AddResource(Resource resource)
        {
            throw new NotImplementedException();
        }


      
    }
}
