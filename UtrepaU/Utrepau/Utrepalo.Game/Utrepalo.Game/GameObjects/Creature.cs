using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.Interfaces;

namespace Utrepalo.Game.GameObjects
{
    using System;
    using System.Collections.Generic;
    using Game = Microsoft.Xna.Framework.Game;

    public abstract class Creature :GameObject, ICreature
    {
        private IEnumerable<Upgrade> upgrades = new List<Upgrade>(); 
        private int resources;
        private int health;
        private int damage;
        private int armor;

        public Creature(Texture2D objTexture,Rectangle drowingRectangle,Rectangle sourceRectangle,SpriteBatch spriteBatch,int resources, int health, int damage, int armor,Game game)
            :base(objTexture,drowingRectangle,sourceRectangle,spriteBatch ,game)
        {
            this.Resourse = resources;
            this.Health = health;
            this.Damage = damage;
            this.Armor = armor;
            this.Upgrades = upgrades;
        }


        public int  Resourse { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }

        public IEnumerable<Upgrade> Upgrades
        {
            get { return this.upgrades; }
            set { this.upgrades = value; }
        }

        public virtual void Attack()
        {
            throw new NotImplementedException();
        }

        public void Defence()
        {
            throw new NotImplementedException();
        }


        public override void RespondToCollision(GameObject hitObject)
        {
            throw new System.NotImplementedException();
        }
    }
}
