using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utrepalo.Core.GameObjects
{
    using Interfaces;

    public abstract class Fighter : IFighter
    {
        private List<Creature> creatures;
        private string name;

        public Fighter(string name )
        {
            this.Name = name;
            this.creatures = new List<Creature>();
        }
        public string Name { get; set; }

        public IEnumerable<Creature> Creatures
        {
            get { return this.creatures; }

        }

        public void AddCreatures(Creature creature)
        {
            this.creatures.Add(creature);
        }
    }
}
