using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.GameObjects;

namespace Utrepalo.Game.GameObjects.Enemies
{
    using System.Collections.Generic;

    public class Warrior : Creature
    {
        private const int WarriorDefaultAttack = 20;
        private const int WarriorDefaultHealthPoints = 300;
        private const int WarriorDefaultShotTimeout = 60;

        public Warrior(Texture2D objTexture, Rectangle rectangle) : base(objTexture, rectangle, WarriorDefaultAttack, WarriorDefaultHealthPoints, WarriorDefaultShotTimeout)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objTexture,this.Rectangle,new Rectangle(0,0,100,100),Color.White);
        }
    }
}
