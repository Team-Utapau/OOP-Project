using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utrepalo.Game.Interfaces
{
    using GameObjects.Resources;

    public interface IEnhanceable
    {
        IEnumerable<Resource> Resources { get; }
        void AddResource (Resource resource);
    }
}
