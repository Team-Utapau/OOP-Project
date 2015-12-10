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
    using Microsoft.Xna.Framework.Content;
    using Game = Microsoft.Xna.Framework.Game;

    public abstract class GameObject: DrawableGameComponent, ICollidable
    {
        protected Texture2D objTexture;
        protected Rectangle drawingRectangle;
        protected Rectangle sourcerRectangle;
        protected SpriteBatch spriteBatch;

        protected GameObject(Texture2D objTexture, Rectangle drowingRectangle,Rectangle sourceRectangle, SpriteBatch spriteBatch,Game game)
            :base(game)
            
        {
            this.ObjTexture = objTexture;
            this.DrowingRectangle = drowingRectangle;
            this.SourceRectangle = sourceRectangle;
            this.spriteBatch = spriteBatch;
        }

        public Rectangle SourceRectangle
        {
            get { return this.sourcerRectangle; }
            set
            {
                //if (value.Width <= 0 || value.Height <= 0)
                //{
                //    throw new Exception("Invalid parameters");
                //}
                this.sourcerRectangle = value;
            }
        }
        public Texture2D ObjTexture
        {
            get { return this.objTexture; }
            set { this.objTexture = value; }
        }

        public SpriteBatch SpriteBatch
        {
            get { return this.spriteBatch; }
            set { this.spriteBatch = value; }
        }

        public Rectangle DrowingRectangle
        {
            get { return this.drawingRectangle; }
            set
            {
                //if (value.Width<=0||value.Height<=0)
                //{
                //    throw new Exception("Invalid parameters");
                //}
                this.drawingRectangle = value;
            }
        }

        //public virtual void Draw(SpriteBatch spriteBatch)
        //{
        //    Rectangle rect = new Rectangle(
        //        this.Rectangle.X - GameEngine.Offset,
        //        this.Rectangle.Y - GameEngine.Offset,
        //        this.Rectangle.Width,
        //        this.Rectangle.Height);

        //    spriteBatch.Draw(this.objTexture,rect,Color.White);
        //}

        public virtual void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual void LoadContent(ContentManager content)
        {
            base.LoadContent();
        }

        public abstract void RespondToCollision(GameObject hitObject);
    }
}
