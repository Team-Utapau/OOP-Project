using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.GameObjects.Walls;

namespace Utrepalo.Game.Test
{
    public class StoneWall : Wall
    {
        //private const int DefaultHealthPoints = 250;

        public StoneWall(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
            //this.HealthPoints = DefaultHealthPoints;
        }

    }
}
