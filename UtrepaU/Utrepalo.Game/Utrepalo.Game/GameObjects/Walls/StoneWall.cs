using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects.Walls
{
    public class StoneWall : Wall
    {

        public StoneWall(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }

        public override void Update()
        {
            
        }

        public override void RespondToCollision(GameObject hitObject)
        {
       
        }
    }
}
