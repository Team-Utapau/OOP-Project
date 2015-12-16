using Utrepalo.Game.GameObjects;

namespace Utrepalo.Game.Interfaces
{
    public interface ICollidable
    {
        void RespondToCollision(GameObject hitObject);
    }
}
