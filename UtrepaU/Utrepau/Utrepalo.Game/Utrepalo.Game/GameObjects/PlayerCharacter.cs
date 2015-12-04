using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Content;

    public class PlayerCharacter : Character
    {
        private int gold;
        private int lifes;
        public PlayerCharacter(Texture2D objTexture,Rectangle rectangle,SpriteBatch spriteBatch
            ,string name,int level)
            :base(objTexture,rectangle,spriteBatch,name)
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

        public void MoveUp(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingUpSprite");
        }

        public void MoveDown(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingDownSprite");
        }
        public void MoveLeft(ContentManager content)
        {
            this.objTexture = content.Load<Texture2D>("images/walkingLeftSprite");
        }
        public void MoveRight(ContentManager content)
        {

            this.objTexture = content.Load<Texture2D>("images/walkingRightSprite");
        }
    }
}
