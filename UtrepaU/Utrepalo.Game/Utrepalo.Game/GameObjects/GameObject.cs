using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.Enums;
using Utrepalo.Game.Exceptions;
using Utrepalo.Game.Interfaces;

namespace Utrepalo.Game.GameObjects
{
    public abstract class GameObject: ICollidable
    {
        protected Texture2D objTexture;
        protected Rectangle rectangle;

        protected GameObject(Texture2D objTexture, Rectangle rectangle)
        {
            this.objTexture = objTexture;
            this.Rectangle = rectangle;
        }

        public Rectangle Rectangle
        {
            get { return this.rectangle; }
            set
            {
                if (value.Width <= 0 || value.Height <= 0)
                {
                    throw new InvalidObjectParametarException("size", "The object should has positive width and height");
                }
                this.rectangle = value;
            }
        }

        public GameObjectState State { get; set; }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle(this.Rectangle.X, this.Rectangle.Y,30,30);
            spriteBatch.Draw(this.objTexture, rect, Color.White);
        }

        public abstract void RespondToCollision(GameObject hitObject);
    }
}
