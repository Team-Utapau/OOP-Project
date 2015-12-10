using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utrepalo.Game.GameObjects.Resources.Items
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class HealingPotion : Resource
    {
        private const int DefaultHelingPotionAttackEffect = 0;
        private const int DefaultHelingPotionHealingEffect = 50;
        private const int DefaultHelingPotionDefenceEffect = 0;


        public HealingPotion(Texture2D objTexture, Rectangle drowingRectangle, Rectangle sourceRectangle, SpriteBatch spriteBatch, Game game) : base(objTexture, drowingRectangle, sourceRectangle, spriteBatch, game, DefaultHelingPotionAttackEffect, DefaultHelingPotionHealingEffect, DefaultHelingPotionDefenceEffect)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            throw new NotImplementedException();
        }
    }
}
