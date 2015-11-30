namespace Utrepalo.Core.GameObjects
{
    using System;
    using System.Collections.Generic;
    using GameObjects.Class;
    using GameObjects.Interfaces;

    public abstract class Creature : ICreature
    {
        private IEnumerable<Upgrade> upgrades = new List<Upgrade>(); 
        private int resources;
        private int health;
        private int damage;
        private int armor;
        private bool isEnemy;
        public Creature(int resources, int health, int damage, int armor,bool isEnemy)
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
    }
}
