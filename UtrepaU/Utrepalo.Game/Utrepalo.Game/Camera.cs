﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utrepalo.Game.GameObjects;

namespace Utrepalo.Game
{
    public class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 centre;

        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void Update(GameTime gameTime,Player player)
        {
            centre = new Vector2(player.Rectangle.X + (player.Rectangle.Width / 2) - 400,
                                    player.Rectangle.Y + (player.Rectangle.Height / 2) - 250);
          

            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        }
    }
}
