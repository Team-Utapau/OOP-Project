using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.Exceptions;
using Utrepalo.Game.Interfaces;
using Utrepalo.Game.Test;

namespace Utrepalo.Game.GameObjects
{
    using Resources.Items;
    using Utrepalo.Game.Enums;
    using Walls;

    public abstract class PlayerCharacter : Character, IMovable
    {
        private double speed;

        public PlayerCharacter(Texture2D objTexture, Rectangle rectangle, int attack, int healtPoints)
            : base(objTexture, rectangle, attack, healtPoints)
        {
            this.Speed = speed;
        }

        public double Speed
        {
            get { return this.speed; }

            protected set
            {
                if (value < 0)
                {
                    throw new InvalidObjectParametarException(
                        "speed",
                        "Speed cannot be negative.");
                }

                this.speed = value;
            }
        }
        public int Coins { get; set; }
        public abstract void Move();

        public override void Update()
        {
            this.PreviousPosition = new Vector2(this.Rectangle.X, this.Rectangle.Y);

            this.CheckBorderCollision();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            if (hitObject is Character || hitObject is Wall)
            {
                this.Rectangle = new Rectangle(
                    (int) this.PreviousPosition.X,
                    (int) this.PreviousPosition.Y,
                    this.Rectangle.Width,
                    this.Rectangle.Height);
            }

            base.RespondToCollision(hitObject);
        }

        public void CheckBorderCollision()
        {
            var walls = GameEngine.GameObjects.Where(c => c is StoneWall).ToList();
            var potions = GameEngine.GameObjects.Where(c => c is HealingPotion).ToList();
            var coints = GameEngine.GameObjects.Where(c => c is Coin).ToList();

            foreach (var coin in coints)
            {
                if (coin.Rectangle.Intersects(this.Rectangle))
                {
                    coin.State=GameObjectState.Destroyed;
                    this.Coins += 1;
                }
            }
            foreach (var wall in walls)
            {
                var previous = this.Rectangle;
                if (wall.Rectangle.Intersects(this.Rectangle))
                {
                    previous.X = (int) this.PreviousPosition.X;
                    previous.Y = (int) this.PreviousPosition.Y;

                }
                this.Rectangle = previous;
            }
            foreach (var potion in potions)
            {
                if (HealthPoints<500)
                {
                    if (potion.Rectangle.Intersects(this.Rectangle))
                    {
                        potion.State = GameObjectState.Destroyed;
                        this.HealthPoints += 100;
                    }
                    if (HealthPoints > 500)
                    {
                        HealthPoints = 500;
                    }
                }
                
            }
        }

    }
}

