using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.GameObjects;

namespace Utrepalo.Game.GameObjects.Enemies
{
    using System.Collections.Generic;

    public class Minion : Creature
    {
        private const int MinionDefaultAttack = 150;
        private const int MinionDefaultHealthPoints = 300;

        public Minion(Texture2D objTexture, Rectangle rectangle) : base(objTexture, rectangle, MinionDefaultAttack, MinionDefaultHealthPoints)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objTexture,this.Rectangle,new Rectangle(0,0,100,100),Color.White);
        }
    }
}
