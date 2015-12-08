using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects.Buttons
{
    public class ExitButton : GameObject
    {

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            throw new NotImplementedException();
        }

        public ExitButton(Texture2D objTexture, Rectangle rectangle, SpriteBatch spriteBatch) : base(objTexture, rectangle, spriteBatch)
        {
        }
    }
}
