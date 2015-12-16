using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.Enums;
using Utrepalo.Game.GameObjects;
using Utrepalo.Game.Interfaces;

namespace Utrepalo.Game.Bullets
{
    using System.Linq;
    using Test;

    public abstract class BaseBullet : GameObject, IAttack, IMovable
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

        public double Speed { get; private set; }

        public abstract void Shoot(Direction direction);

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
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            //if (hitObject is Character || hitObject is Obstacle)
            //{
            //    this.State = GameObjectState.Destroyed;
            //    SoundHandler.HandleDestroyObjectSoundEffect();
            //}
        }

        private void CheckOutOfBounds()
        {
            //if (this.Rectangle.X < -GameEngine.Offset ||
            //    this.Rectangle.X > GameEngine.WindowsWidth + GameEngine.Offset ||
            //    this.Rectangle.Y < -GameEngine.Offset ||
            //    this.Rectangle.Y > GameEngine.WindowsHeight + GameEngine.Offset)
            //{
            //    this.State = GameObjectState.Destroyed;
            //}
            var walls = GameEngine.GameObjects.Where(c => c is StoneWall).ToList();
            foreach (var wall in walls)
            {
                if (this.Rectangle.Intersects(wall.Rectangle))
                {
                    this.State = GameObjectState.Destroyed;
                }
            }
        }
    }
}
