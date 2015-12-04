using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects
{
    using System.Collections.Generic;

    public class EnemyCharacter : Character
    {
        private int level;
        public EnemyCharacter(Texture2D objTexture,Rectangle rectangle,SpriteBatch spriteBatch,string name,int level)
            :base(objTexture,rectangle,spriteBatch,name)
        {
            this.Level = level;
        }
        public int Level { get; set; }
        public override void AddCreatures(Creature creature)
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            throw new System.NotImplementedException();
        }
    }
}
