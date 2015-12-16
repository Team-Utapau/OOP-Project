using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utrepalo.Game.Enums;

namespace Utrepalo.Game.GameObjects.Resources.Items
{
    public abstract class CollectibleItem : GameObject
    {
        protected CollectibleItem(Texture2D objTexture, Rectangle rectangle, int healthEffect) : base(objTexture, rectangle)
        {
            this.HealthEffect = healthEffect;
        }

        public int HealthEffect { get; set; }

        public CollectibleItemState ItemState { get; set; }

        public override void Update()
        {
            if (this.ItemState == CollectibleItemState.Collected)
            {
                this.ItemState = CollectibleItemState.Active;
                this.Rectangle = new Rectangle(-999, -999, 1, 1);
            }
        }
        public override void RespondToCollision(GameObject hitObject)
        {
            //if (hitObject is ICollect)
            //{
            //    this.ItemState = CollectibleItemState.Collected;
            //}
        }
    }
}
