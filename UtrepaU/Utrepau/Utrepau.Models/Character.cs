using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utrepau
{
    public class Character
    {
        private ICollection<Creature> creatures;
        private ICollection<Enemy> enemies;

        public Character()
        {
            this.creatures = new HashSet<Creature>();
            this.enemies = new HashSet<Enemy>();

        }
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Gold { get; set; }
        [Required]
        public int NumberOfLifes { get; set; }
        public virtual Talent Talent { get; set; }
        [Required]
        public int TalentId { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Creature> Creatures { get; set; }
        public virtual ICollection<Enemy> Enemies { get; set; }
    }
}
