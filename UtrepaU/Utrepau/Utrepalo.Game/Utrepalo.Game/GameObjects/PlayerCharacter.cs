using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;
    using FuncWorks.XNA.XTiled;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Input;

    public class PlayerCharacter : Character
    {
        private int gold;
        private int lifes;
        float elapsed;
        public float delay = 200;
        public int frames = 0;
        double actionTimer = 0;
        public PlayerCharacter(Texture2D objTexture,Rectangle rectangle,SpriteBatch spriteBatch,string name,int level)
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

        private void MoveSprite(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                if (frames >= 7)
                {
                    frames = 0;
                }
                else
                {
                    frames++;
                }
                elapsed = 0;
            }
        }
        public void PlayerMoveState(GameTime gameTime, KeyboardState keys,Rectangle mapView,ContentManager Content,
            List<Map> maps, int mapIdx,Rectangle destRect)
        {

            Rectangle delta = mapView;
            if (keys.IsKeyDown(Keys.Down))
            {
                
                MoveSprite(gameTime);
                this.MoveDown(Content);
            }
                
            if (keys.IsKeyDown(Keys.Up))
                delta.Y -= 1;
            if (keys.IsKeyDown(Keys.Right))
                delta.X += 1;

            if (keys.IsKeyDown(Keys.Left))
                delta.X -= 1;
            {
                MoveSprite(gameTime);
                MoveDown(Content);
            }
            if (keys.IsKeyDown(Keys.Up))
            {
                MoveSprite(gameTime);
                MoveUp(Content);
            }

            if (keys.IsKeyDown(Keys.Right))
            {
                MoveSprite(gameTime);
                MoveRight(Content);
            }

            if (keys.IsKeyDown(Keys.Left))
            {
                MoveSprite(gameTime);
                MoveLeft(Content);
            }
            if (keys.GetPressedKeys().Count() == 0)
            {
                frames = 0;
            }


            if (maps[mapIdx].Bounds.Contains(delta))
            {
                destRect.X += delta.X - mapView.X;
                destRect.Y += delta.Y - mapView.Y;
                mapView.X = delta.X;
                mapView.Y = delta.Y;
            }
        }
    }
}
