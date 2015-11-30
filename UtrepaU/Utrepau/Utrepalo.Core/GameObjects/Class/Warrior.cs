namespace Utrepalo.Core.GameObjects.Class
{
    using System.Collections.Generic;

    public class Warrior : Creature
    {
       public Warrior(int resources, int health, int damage, int armor, bool isEnemy)
            :base(resources,health,damage,armor,isEnemy)
        {
        }
    }
}
