using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects
{
    using Enums;
    using Walls;
    using System.Linq;

    public class Creature : Character
    {
        private const int DefaultEnemyRange = 130;

        public Creature(Texture2D objTexture, Rectangle rectangle, int attack, int healtPoints)
                          : base(objTexture, rectangle, attack, healtPoints)
        {

        }

        public override void Update()
        {
            var player = GameEngine.GameObjects.FirstOrDefault(p => p is PlayerCharacter) as Player;

            // Left
            if (this.Rectangle.Y - 20 <= player.Rectangle.Y && player.Rectangle.Y < this.Rectangle.Y)
            {
                if (this.Rectangle.X > player.Rectangle.X && player.Rectangle.X >= this.Rectangle.X - DefaultEnemyRange)
                {
                    this.Shoot(Direction.Left);
                }
                else if (this.Rectangle.X < player.Rectangle.X && player.Rectangle.X <= this.Rectangle.X + DefaultEnemyRange)
                {
                    this.Shoot(Direction.Right);
                }

            }
            if (this.Rectangle.X - 20 <= player.Rectangle.X && player.Rectangle.X < this.Rectangle.X)
            {
                if (this.Rectangle.Y > player.Rectangle.Y && player.Rectangle.Y >= this.Rectangle.Y - DefaultEnemyRange)
                {
                    this.Shoot(Direction.Up);
                }
                else if (this.Rectangle.Y < player.Rectangle.Y && player.Rectangle.Y <= this.Rectangle.Y + DefaultEnemyRange)
                {
                    this.Shoot(Direction.Down);
                }
            }

        }


        public override void RespondToCollision(GameObject hitObject)
        {
            if (hitObject is Character || hitObject is Wall)
            {
                this.Rectangle = new Rectangle(
                    (int)this.PreviousPosition.X,
                    (int)this.PreviousPosition.Y,
                    this.Rectangle.Width,
                    this.Rectangle.Height);
            }

            var player = hitObject as PlayerCharacter;

            if (player != null)
            {
                player.HealthPoints -= this.Attack;
                player.State = GameObjectState.Damaged;
            }

            if (this.HealthPoints <= 0)
            {
                this.State = GameObjectState.Destroyed;
            }
        }
    }
}