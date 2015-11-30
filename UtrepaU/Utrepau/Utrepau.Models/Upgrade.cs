using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utrepau
{
    public class Upgrade
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Cost { get; set; }
        public virtual Stat Stats { get; set; }
        [Required]
        public int StatsId { get; set; }
        public virtual Creature Creature { get; set; }
        [Required]
        public int CreatureId { get; set; }


    }
}
