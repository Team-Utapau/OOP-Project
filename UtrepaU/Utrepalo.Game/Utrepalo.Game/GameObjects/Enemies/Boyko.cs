using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utrepalo.Game.GameObjects.Enemies
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Boyko : Creature
    {
        private const int BoykoDefaultAttack = 250;
        private const int BoykoDefaultHealthPoints = 1000;
        private const int BoykoDefaultShotTimeout = 50;

        public Boyko(Texture2D objTexture, Rectangle rectangle) : base(objTexture, rectangle, BoykoDefaultAttack, BoykoDefaultHealthPoints,BoykoDefaultShotTimeout)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objTexture, this.Rectangle, new Rectangle(0, 0, 100, 100), Color.White);
        }
    }
}
