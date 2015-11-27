using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utrepau
{
    public class Creature
    {
        private ICollection<Upgrade> upgrades;

        public Creature()
        {
            this.upgrades = new HashSet<Upgrade>();
        }
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public bool IsEnemy { get; set; }
        [Required]
        public int Resource { get; set; }
        [Required]
        public int StatsId { get; set; }
        [Required]
        public CreatureType Type { get; set; }

        public virtual ICollection<Upgrade> Upgrades { get; set; }
    }
}
