using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game;
using Utrepalo.Game.Interfaces;

namespace Utrepalo.Game.GameObjects
{
    public abstract class GameObject:ICollidable
    {
        protected Texture2D objTexture;
        protected Rectangle rectangle;
        protected SpriteBatch spriteBatch;

        protected GameObject(Texture2D objTexture, Rectangle rectangle,SpriteBatch spriteBatch)
        {
            this.objTexture = objTexture;
            this.rectangle = rectangle;
            this.spriteBatch = spriteBatch;
        }

        public Texture2D ObjTexture
        {
            get { return this.objTexture; }
            set { this.objTexture = value; }
        }
        public Rectangle Rectangle
        {
            get { return this.rectangle; }
            set
            {
                if (value.Width<=0||value.Height<=0)
                {
                    throw new Exception("Invalid parameters");
                }
                this.rectangle = value;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle(
                this.Rectangle.X - GameEngine.Offset,
                this.Rectangle.Y - GameEngine.Offset,
                this.Rectangle.Width,
                this.Rectangle.Height);

            spriteBatch.Draw(this.objTexture,rect,Color.White);
        }
        public abstract void Update();
        public abstract void RespondToCollision(GameObject hitObject);
    }
}
