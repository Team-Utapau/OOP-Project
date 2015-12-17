using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.Enums;
using Utrepalo.Game.GameObjects;
using Utrepalo.Game.GameObjects.Enemies;
using Utrepalo.Game.Interfaces;

namespace Utrepalo.Game.Bullets
{
    using System.Linq;
    using Test;

    public abstract class BaseBullet : GameObject, IMovable
    {
        private const int DefaultSpeed = 6;

        protected BaseBullet(
            Texture2D objTexture,
            Rectangle rectangle,
            Direction direction)
            : base(objTexture, rectangle)
        {
            this.Speed = DefaultSpeed;
            this.Direction = direction;
        }

        public Direction Direction { get; protected set; }

        public double Speed { get; protected set; }
        
        public bool isEnemyBullet { get; set; }

        public void Move()
        {
            switch (this.Direction)
            {
                case Direction.Up:
                    this.Rectangle = new Rectangle(
                        this.Rectangle.X,
                        (int)(this.Rectangle.Y - this.Speed),
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
                case Direction.Down:
                    this.Rectangle = new Rectangle(
                        this.Rectangle.X,
                        (int)(this.Rectangle.Y + this.Speed),
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
                case Direction.Left:
                    this.Rectangle = new Rectangle(
                        (int)(this.Rectangle.X - this.Speed),
                        this.Rectangle.Y,
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
                case Direction.Right:
                    this.Rectangle = new Rectangle(
                        (int)(this.Rectangle.X + this.Speed),
                        this.Rectangle.Y,
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
            }
        }

        public override void Update()
        {
            this.Move();
            this.CheckOutOfBounds();
            this.CheckIfHit();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            if (hitObject is Character)
            {
                this.State = GameObjectState.Destroyed;
            }
        }

        private void CheckOutOfBounds()
        {
            var walls = GameEngine.GameObjects.Where(c => c is StoneWall).ToList();
            foreach (var wall in walls)
            {
                if (this.Rectangle.Intersects(wall.Rectangle))
                {
                    this.State = GameObjectState.Destroyed;
                }
            }
        }
        private void CheckIfHit()
        {
            var creautures = GameEngine.GameObjects.Where(c => c is Creature).ToList();
            var player = GameEngine.GameObjects.FirstOrDefault(p => p is PlayerCharacter) as Player;
            foreach (var creauture in creautures)
            {
                var enemy = creauture as Creature;
                if (this.Rectangle.Intersects(creauture.Rectangle))
                {
                    enemy.HealthPoints -= player.Attack;
                    this.State = GameObjectState.Destroyed;
                }
            }
            if (this.Rectangle.Intersects(player.Rectangle))
            {
                var creature = creautures.First() as Warrior;
                player.HealthPoints -= creature.Attack;
            }
        }
    }
}
