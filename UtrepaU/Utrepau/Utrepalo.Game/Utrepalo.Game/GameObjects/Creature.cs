using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.Bullets;
using Utrepalo.Game.Interfaces;

namespace Utrepalo.Game.GameObjects
{
    using System;
    using System.Collections.Generic;
    using Game = Microsoft.Xna.Framework.Game;

    public  class Creature :GameObject, ICreature
    {
        private IEnumerable<Upgrade> upgrades = new List<Upgrade>();
        public Texture2D bulletTexture;
        private int health;
        private int damage;
        private int armor;
        private float bulletDelay;
        private List<Bullet> bullets;
        private bool bulletAvailable;

        public Creature(Texture2D objTexture,Rectangle drowingRectangle,Rectangle sourceRectangle,SpriteBatch spriteBatch, int health, int damage, int armor,Game game)
            :base(objTexture,drowingRectangle,sourceRectangle,spriteBatch ,game)
        {
            this.Health = health;
            this.Damage = damage;
            this.Armor = armor;
            this.Upgrades = upgrades;
            this.bullets=new List<Bullet>();
        }


        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }

        public IEnumerable<Upgrade> Upgrades
        {
            get { return this.upgrades; }
            set { this.upgrades = value; }
        }

        public virtual void Attack()
        {
            throw new NotImplementedException();
        }

        public void Defence()
        {
            throw new NotImplementedException();
        }


        public override void RespondToCollision(GameObject hitObject)
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objTexture,new Vector2(250,250), SourceRectangle, Color.White);
            foreach (var bullet in bullets)
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
                var newBullet = new Bullet(bulletTexture);
                newBullet.position=new Vector2(250,250);
                newBullet.isVisible = true;
                bulletAvailable = false;
                if (bullets.Count<1)
                {
                    bullets.Add(newBullet);
                }
            }
            if (bulletDelay==0)
            {
                bulletDelay = 1;
            }
        }

        public override void Update(GameTime gameTime)
        {
            this.SourceRectangle = new Rectangle(48 , 0, 44, 46);
            Shoot();
            UpdateBullets();

        }

        public void UpdateBullets()
        {
            foreach (var bullet in bullets)
            {
                bullet.position.X = bullet.position.X - 1;

                if (bullet.position.X<=50)
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

        public override void LoadContent(ContentManager content)
        {
            this.bulletTexture = content.Load<Texture2D>("images/bullet");
            this.ObjTexture = content.Load<Texture2D>("images/walkingLeftSprite");
        }
    }
}
