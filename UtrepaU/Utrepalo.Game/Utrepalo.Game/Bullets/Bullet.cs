using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.Enums;

namespace Utrepalo.Game.Bullets
{
    public class Bullet : BaseBullet
    {
        public Bullet(Texture2D objTexture, Rectangle rectangle, Direction direction) : base(objTexture, rectangle, direction)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.objTexture, this.Rectangle, Color.White);
        }
    }
}
