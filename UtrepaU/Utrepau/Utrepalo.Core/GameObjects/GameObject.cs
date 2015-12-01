using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Core.GameObjects.Interfaces;
using Utrepalo.Game;

namespace Utrepalo.Core.GameObjects
{
    public abstract class GameObject:ICollidable
    {
        protected Texture2D objTexture;
        protected Rectangle rectangle;

        protected GameObject(Texture2D objTexture, Rectangle rectangle)
        {
            this.objTexture = objTexture;
            this.rectangle = rectangle;
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
