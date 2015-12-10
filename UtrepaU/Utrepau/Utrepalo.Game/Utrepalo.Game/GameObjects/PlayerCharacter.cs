using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Content;
    using Bullets;
    using Microsoft.Xna.Framework.Input;

    public class PlayerCharacter /*: Character*/
    {
        public Texture2D objTexture;
        public Texture2D bulletTexture;
        public Rectangle sourceRectangle;
        public float bulletDelay;
        public Vector2 position;
        public float elapsed;
        public double delay = 200;
        public int frame;
        public int speed;
        private List<Bullet> bullets;


        private int gold;
        private int lifes;
       

        public PlayerCharacter()
                              //: base(objTexture, rectangle, spriteBatch, name)
        {
            this.bullets = new List<Bullet>();
            this.speed = 2;
            this.bulletDelay =  1f;
            //this.sourceRectangle = new Rectangle();

            this.Gold = gold;
            this.Lifes = lifes;
        }
        public int Gold  { get; set; }
        public int Lifes { get; set; }

        //public IEnumerable<Bullet> Bullets
        //{
        //    get { return this.bullets; }
        //}

        //public void AddBullet(Bullet bullet)
        //{
        //    this.bullets.Add(bullet);
        //}

        //public override void Update()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override void RespondToCollision(GameObject hitObject)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override void AddCreatures(Creature creature)
        //{
        //    throw new System.NotImplementedException();
        //}

        public void LoadContent(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingdownsprite");
            //MoveUp(content);
            //MoveDown(content);
            //MoveRight(content);
            //MoveLeft(content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objTexture, position, sourceRectangle, Color.White);
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

                if (bullets.Count < 20)
                {
                    bullets.Add(newBullet);
                }
            }

            if (bulletDelay == 0)
            {
                bulletDelay = 20;
            }
        }

        public void Update(GameTime gameTime)
        {
            sourceRectangle = new Rectangle(48 * frame, 0, 44, 46);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space))
            {
                Shoot();
            }

            UpdateBullets();

            if (keyState.IsKeyDown(Keys.Up))
            {
                position.Y = position.Y - speed;
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                position.Y = position.Y + speed;
            }

            if (keyState.IsKeyDown(Keys.Right))
            {
                position.X = position.X + speed;
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                position.X = position.X - speed;
            }
        }

        public void UpdateBullets()
        {
            foreach (Bullet bullet in this.bullets)
            {
                bullet.position.Y = bullet.position.Y - bullet.speed;

                if (bullet.position.Y <= 0)
                {
                    bullet.isVisible = false;
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
            this.bulletTexture = content.Load<Texture2D>("images/bullet");
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
    }
}
