using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utrepau.Data.Repository;

namespace Utrepau.Data.UnitOfWork
{
    public class UtrepauData : IUtrepauData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;


        public UtrepauData()
            : this(new UtrepauContext())
        {
        }
        public UtrepauData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Character> Characters
        {
            get { return this.GetRepository<Character>(); }
        }

        public IRepository<Creature> Creatures
        {
            get { return this.GetRepository<Creature>(); }
        }

        public IRepository<Enemy> Enemies
        {
            get { return this.GetRepository<Enemy>(); }
        }

        public IRepository<Stat> Stats
        {
            get { return this.GetRepository<Stat>(); }
        }
        public IRepository<Talent> Talents
        {
            get { return this.GetRepository<Talent>(); }
        }
        public IRepository<Upgrade> Upgrades
        {
            get { return this.GetRepository<Upgrade>(); }
        }

       

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }


        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
