using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utrepau
{
    public class Enemy
    {
        private ICollection<Creature> creatures;

        public Enemy()
        {
            this.creatures=new HashSet<Creature>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public virtual ICollection<Creature> Creatures { get; set; } 
    }
}
