using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utrepalo.Game.GameObjects.Resources.Items
{
    using Enums;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Coin : GameObject
    {
        public override void Update()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle(this.Rectangle.X, this.Rectangle.Y, 27,27);
            spriteBatch.Draw(this.objTexture, rect, Color.White);
        }

        public override void RespondToCollision(GameObject hitObject)
        {

        }


        public Coin(Texture2D objTexture, Rectangle rectangle) : base(objTexture, rectangle)
        {
        }
    }
}
