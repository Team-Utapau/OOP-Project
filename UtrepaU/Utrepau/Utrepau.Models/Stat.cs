using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utrepau
{
    public class Stat
    {
        private ICollection<Creature> creatures;

        public Stat()
        {
            this.creatures=new HashSet<Creature>();
        }
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int Damage { get; set; }
        [Required]
        public int Health { get; set; }
        [Required]
        public int Armor { get; set; }

        public virtual ICollection<Creature> Creatures { get; set; }
    }
}
