﻿namespace Utrepalo.Core.GameObjects.Class
{
    using System.Collections.Generic;

    public class Paladin : Creature
    {
        public Paladin(int resources, int health, int damage,int armor,bool isEnemy )
            :base(resources,health,damage,armor,isEnemy)
        {
        }
    }
}
