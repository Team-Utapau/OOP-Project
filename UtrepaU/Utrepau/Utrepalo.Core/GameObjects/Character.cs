namespace Utrepalo.Core.GameObjects
{
    using System.Collections.Generic;

    public class Character : Fighter
    {
        private int gold;
        private int lifes;
        public Character(string name)
            :base(name)
        {
            this.Gold = gold;
            this.Lifes = lifes;

        }
        public int Gold  { get; set; }
        public int Lifes { get; set; }

    }
}
