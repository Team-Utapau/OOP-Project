using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.Bullets;
using Utrepalo.Game.Enums;
using Utrepalo.Game.Interfaces;

namespace Utrepalo.Game.GameObjects
{
    using System.Linq;
    using Enemies;

    public abstract class Character : GameObject, IAttack, IDestroyable
    {
        protected Character(Texture2D objTexture, Rectangle rectangle, int attack, int healtPoints) : base(objTexture, rectangle)
        {
            this.Attack = attack;
            this.HealthPoints = healtPoints;
        }

        public int Attack { get; protected set; }

        public int HealthPoints { get; protected internal set; }

        public Direction Direction { get; protected set; }

        public bool HasShot { get; protected set; }

        protected Vector2 PreviousPosition { get; set; }

        public override void RespondToCollision(GameObject hitObject)
        {
            var currentType = this.GetType().Name;
            var enemyType = "";
            switch (currentType)
            {
                case "Warrior":
                    enemyType = "Player";
                    break;
                case "Player":
                    enemyType = "Warrior";
                    break;
                case "Boyko":
                    enemyType = "Player";
                    break;

                default:
                    break;
            }

            if (hitObject is BaseBullet)
            {
                BaseBullet bullet = (BaseBullet)hitObject;
                if (enemyType.Equals("Minion"))
                {
                    var warrior = GameEngine.GameObjects.FirstOrDefault(w => w is Minion) as Minion;
                    this.HealthPoints -= warrior.Attack;
                }
                if (enemyType.Equals("Minion"))
                {
                    var boyko = GameEngine.GameObjects.FirstOrDefault(w => w is Boyko) as Boyko;
                    this.HealthPoints -= boyko.Attack;
                }
                else if (enemyType.Equals("Player"))
                {
                    var player = GameEngine.GameObjects.FirstOrDefault(w => w is Player) as Player;
                    this.HealthPoints -= player.Attack;
                }
                this.State = GameObjectState.Damaged;
            }

            if (this.HealthPoints <= 0)
            {
                this.State = GameObjectState.Destroyed;
            }
        }

        public void Shoot(Direction direction)
        {
            Rectangle bulletPosition;
            int rectangleBulletMinimizedWidth = 16;
            int rectangleBulletMinimizedHeight = 16;
            switch (direction)
            {
                case Direction.Down:
                    bulletPosition = new Rectangle(
                        this.Rectangle.X + (this.Rectangle.Width / 3),
                        this.Rectangle.Y + this.Rectangle.Height,
                        rectangleBulletMinimizedWidth,
                        rectangleBulletMinimizedHeight);
                    break;
                case Direction.Up:
                    bulletPosition = new Rectangle(
                        this.Rectangle.X + (this.Rectangle.Width / 3),
                        this.Rectangle.Y - (this.Rectangle.Height / 2),
                        rectangleBulletMinimizedWidth,
                        rectangleBulletMinimizedHeight);
                    break;
                case Direction.Left:
                    bulletPosition = new Rectangle(
                        this.Rectangle.X - (this.Rectangle.Width / 2),
                        this.Rectangle.Y + (this.Rectangle.Height / 4),
                        rectangleBulletMinimizedWidth,
                        rectangleBulletMinimizedHeight);
                    break;
                case Direction.Right:
                    bulletPosition = new Rectangle(
                        this.Rectangle.X + this.Rectangle.Width,
                        this.Rectangle.Y + (this.Rectangle.Height / 4),
                        rectangleBulletMinimizedWidth,
                        rectangleBulletMinimizedHeight);
                    break;
                default:
                    throw new Exception();
            }
            var currentType = this.GetType().Name;
            switch (currentType)
            {
                case "Minion":
                    GameEngine.GameObjects.Add(new Bullet(GameEngine.EnemyBulletTexture, bulletPosition, direction));
                    break;
                case "Boyko":
                    GameEngine.GameObjects.Add(new Bullet(GameEngine.BoykoBulletTexture, bulletPosition, direction));
                    break;
                case "Player":
                    GameEngine.GameObjects.Add(new Bullet(GameEngine.BulletTexture, bulletPosition, direction));
                    break;

            }
           
        }
    }
}
