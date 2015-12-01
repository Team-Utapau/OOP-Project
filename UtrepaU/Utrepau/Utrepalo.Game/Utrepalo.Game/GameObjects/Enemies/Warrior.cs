using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.GameObjects;

namespace Utrepalo.Game.GameObjects.Enemies
{
    using System.Collections.Generic;

    public class Warrior : Creature
    {
       public Warrior(Texture2D objTexture,Rectangle rectangle,int resources, int health, int damage, int armor, bool isEnemy)
            :base(objTexture,rectangle,resources,health,damage,armor,isEnemy)
        {
        }

      
    }
}
