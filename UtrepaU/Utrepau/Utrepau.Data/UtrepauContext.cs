using Utrepau.Data.Migrations;

namespace Utrepau.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UtrepauContext : DbContext
    {

        public UtrepauContext()
            : base("UtrepauContext")
        {
            var migrations = new MigrateDatabaseToLatestVersion<UtrepauContext, Configuration>();
            Database.SetInitializer(migrations);
        }
        public virtual IDbSet<Character> Characters { get; set; } 
        public virtual IDbSet<User> Users { get; set; } 
        public virtual IDbSet<Creature> Creatures { get; set; } 
        public virtual IDbSet<Enemy> Enemies { get; set; } 
        public virtual IDbSet<Stat> Stats { get; set; } 
        public virtual IDbSet<Talent> Talents { get; set; } 
        public virtual IDbSet<Upgrade> Upgrades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasRequired(c => c.User).WithMany()
                .HasForeignKey(c=>c.UserId).WillCascadeOnDelete(false);
        }
    }
    

}