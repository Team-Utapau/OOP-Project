﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Core.GameObjects.Class
{
    using System.Collections.Generic;

    public class Mage : Creature
    {
        public Mage(Texture2D objTexture,Rectangle rectangle,int resources, int health, int damage, int armor, bool isEnemy)
            :base(objTexture,rectangle,resources,health,damage,armor,isEnemy)
        {
        }

        
    }
}
