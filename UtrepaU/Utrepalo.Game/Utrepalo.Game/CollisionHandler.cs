using System.Linq;
using Microsoft.Xna.Framework;
using Utrepalo.Game.Bullets;
using Utrepalo.Game.GameObjects;
using Utrepalo.Game.GameObjects.Walls;

namespace Utrepalo.Game
{
    using Test;

    public static class CollisionHandler
    {
        public static GameObject GetCollisionInfo(GameObject obj)
        {
            var collidingObject = GameEngine.GameObjects
                .FirstOrDefault(gameObject => (!gameObject.Equals(obj) && gameObject.Rectangle.Intersects(obj.Rectangle)));

            if (obj is Wall)
            {
                collidingObject = GameEngine.GameObjects.FirstOrDefault(gameObject => (gameObject is StoneWall) && gameObject.Rectangle.Intersects(obj.Rectangle));
            }

            return collidingObject;
        }

        public static bool ObstaclesObstructingView(Rectangle rect)
        {
            var obstacles = GameEngine.GameObjects.Where(
                    gameObject => (gameObject is Wall /*|| gameObject is EnemyTank || gameObject is Bunker*/) && gameObject.Rectangle.Intersects(rect));

            return obstacles.Any();
        }
    }
}
