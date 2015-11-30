namespace Utrepalo.Core.GameObjects
{
    using System.Collections.Generic;

    public class Enemy : Fighter
    {
        private int level;
        public Enemy(string name,int level )
            :base(name)
        {
            this.Level = level;
        }
        public int Level { get; set; }
    }
}
