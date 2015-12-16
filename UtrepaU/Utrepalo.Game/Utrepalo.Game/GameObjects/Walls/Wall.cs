using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects.Walls
{
    public abstract class Wall : GameObject/*, IDestroyable*/
    {
        protected Wall(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }

        //public int HealthPoints { get; protected set; }

        //public int PhysicalDefense { get; protected set; }

        public override void Update()
        {
            //if (this.HealthPoints <= 0)
            //{
            //    this.State = GameObjectState.Intact;
            //}
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            //var ammunition = hitObject as BaseBullet;

            //if (ammunition != null)
            //{
            //    this.HealthPoints -= 10;
            //}
        }
    }
}
