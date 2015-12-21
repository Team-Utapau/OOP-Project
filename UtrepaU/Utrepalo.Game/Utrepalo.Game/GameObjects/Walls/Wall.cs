using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects.Walls
{
    public abstract class Wall : GameObject
    {
        protected Wall(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }
    }
}
