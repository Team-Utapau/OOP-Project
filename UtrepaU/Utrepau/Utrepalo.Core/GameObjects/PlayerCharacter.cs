using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Core.GameObjects
{
    using System.Collections.Generic;

    public class PlayerCharacter : Character
    {
        private int gold;
        private int lifes;
        public PlayerCharacter(Texture2D objTexture,Rectangle rectangle,string name,int level)
            :base(objTexture,rectangle,name)
        {
            this.Gold = gold;
            this.Lifes = lifes;

        }
        public int Gold  { get; set; }
        public int Lifes { get; set; }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            throw new System.NotImplementedException();
        }

        public override void AddCreatures(Creature creature)
        {
            throw new System.NotImplementedException();
        }
    }
}
