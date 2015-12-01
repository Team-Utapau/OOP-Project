namespace Utrepalo.Core.GameObjects
{
    using System.Collections.Generic;

    public class EnemyCharacter : Character
    {
        private int level;
        public EnemyCharacter(string name,int level )
            :base(name)
        {
            this.Level = level;
        }
        public int Level { get; set; }
    }
}
