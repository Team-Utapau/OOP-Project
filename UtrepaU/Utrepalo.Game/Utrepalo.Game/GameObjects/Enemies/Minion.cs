using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.GameObjects;

namespace Utrepalo.Game.GameObjects.Enemies
{
    using System.Collections.Generic;

    public class Minion : Creature
    {
        private const int MinionDefaultAttack = 120;
        private const int MinionDefaultHealthPoints = 200;
        private const int MinionDefaultShotTimeout = 60;

        public Minion(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, MinionDefaultAttack, MinionDefaultHealthPoints, MinionDefaultShotTimeout)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objTexture,this.Rectangle,new Rectangle(0,0,100,100),Color.White);
        }
    }
}
