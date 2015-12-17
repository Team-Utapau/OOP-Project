using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects
{
    using Enums;
    using Walls;
    using System.Linq;

    public class Creature : Character
    {
        private int shotTimeout;

        private const int DefaultEnemyRange = 130;

        public Creature(Texture2D objTexture, Rectangle rectangle, int attack, int healtPoints, int timeBetweenShots) : base(objTexture, rectangle, attack, healtPoints)
        {
            this.TimeBetweenShot = timeBetweenShots;
            this.shotTimeout = this.TimeBetweenShot;
        }

        protected int TimeBetweenShot { get; set; }

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

        private void OpenFiringSequence(Direction direction)
        {
            this.shotTimeout--;

            if (this.shotTimeout <= 0)
            {
                //this.Speed = 0;
                this.Direction = direction;
                base.Shoot(direction);
                this.shotTimeout = this.TimeBetweenShot;
            }
        }

        public override void Shoot(Direction direction)
        {
            this.OpenFiringSequence(direction);
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