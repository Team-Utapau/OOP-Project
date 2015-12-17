﻿using System.Linq;
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
        private int coins;

        public PlayerCharacter(Texture2D objTexture, Rectangle rectangle, int attack, int healtPoints)
            : base(objTexture, rectangle, attack, healtPoints)
        {
            this.Speed = speed;
            this.coins = Coins;
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
            if (this.HealthPoints <= 0)
            {
                this.State=GameObjectState.Destroyed;;
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

            var creature = hitObject as Character;

            if (creature != null)
            {
                creature.HealthPoints -= this.Attack;
                creature.State = GameObjectState.Damaged;
            }

            if (this.HealthPoints <= 0)
            {
                this.State = GameObjectState.Destroyed;
            }
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
                    this.Coins += 2;
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

