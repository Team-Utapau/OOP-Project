using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utrepau.Data.Repository;

namespace Utrepau.Data.UnitOfWork
{
    public interface IUtrepauData
    {
        IRepository<User> Users { get; }

        IRepository<Character> Characters { get; }

        IRepository<Creature> Creatures { get; }

        IRepository<Enemy> Enemies { get; }

        IRepository<Stat> Stats { get; }
        IRepository<Talent> Talents { get; }
        IRepository<Upgrade> Upgrades { get; }
        

        int SaveChanges();
    }
}
