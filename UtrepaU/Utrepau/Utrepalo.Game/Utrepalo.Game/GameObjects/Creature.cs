using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.Interfaces;

namespace Utrepalo.Game.GameObjects
{
    using System;
    using System.Collections.Generic;

    public abstract class Creature :GameObject, ICreature
    {
        private IEnumerable<Upgrade> upgrades = new List<Upgrade>(); 
        private int resources;
        private int health;
        private int damage;
        private int armor;
        private bool isEnemy;
        public Creature(Texture2D objTexture,Rectangle rectangle,int resources, int health, int damage, int armor,bool isEnemy)
            :base(objTexture,rectangle)
        {
            this.Resourse = resources;
            this.Health = health;
            this.Damage = damage;
            this.Armor = armor;
            this.Upgrades = upgrades;
            this.IsEnemy = isEnemy;
        }


        public int  Resourse { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public bool IsEnemy { get; set; }

        public IEnumerable<Upgrade> Upgrades
        {
            get { return this.upgrades; }
            set { this.upgrades = value; }
        }

        public virtual void Walk()
        {
            throw new NotImplementedException();
        }

        public virtual void Attack()
        {
            throw new NotImplementedException();
        }
        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            throw new System.NotImplementedException();
        }
    }
}
