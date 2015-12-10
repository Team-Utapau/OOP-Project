using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.GameObjects;

namespace Utrepalo.Game.Bullets
{
    public class Bullet /*: GameObject*/
    {
        public Rectangle boundingBox;
        public Texture2D texture;
        public Vector2 origin;
        public Vector2 position;
        public bool isVisible;
        public float speed;

        private float velocity;
        private string bulletDirection;
        private List<Bullet> bulletsOnScreen;

        public Bullet(Texture2D objTexture)/* : base(objTexture, rectangle, spriteBatch)*/
        {
            speed = 10;
            texture = objTexture;
            isVisible = false;
            //this.Velocity = velocity;
            //this.bulletsOnScreen = new List<Bullet>();
        }

        //public override void RespondToCollision(GameObject hitObject)
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Update()
        //{
        //    throw new NotImplementedException();
        //}
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public float Velocity
        {
            get { return this.velocity; }
            set { this.velocity = value; }
        }

        public string BulletDirection
        {
            get;
            set;
        }

        public IEnumerable<Bullet> BulletsOnScreen
        {
            get { return this.bulletsOnScreen; }
        }

        public void AddBullet(Bullet bullet)
        {
            this.bulletsOnScreen.Add(bullet);
        }


    }
}
