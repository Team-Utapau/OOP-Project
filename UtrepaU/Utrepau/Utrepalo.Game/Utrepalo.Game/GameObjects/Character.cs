using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utrepalo.Game.GameObjects
{
    using Interfaces;

    public abstract class Character :GameObject, ICharacter
    {
        private List<Creature> creatures;
        private string name;
        
        public Character(Texture2D objTexture,Rectangle rectangle,SpriteBatch spriteBatch,string name)
            :base(objTexture,rectangle,spriteBatch)
        {
            this.Name = name;
            this.creatures = new List<Creature>();
        }
        public string Name { get; set; }

        public IEnumerable<Creature> Creatures
        {
            get { return this.creatures; }

        }

        public abstract void AddCreatures(Creature creature);
    }
}
