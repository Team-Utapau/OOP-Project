namespace Utrepalo.Game.KeyboardHandler
{
    using System;
    using Interfaces;
    using Microsoft.Xna.Framework.Input;

    public class KeyboardController : IController
    {
        private const int Timeout = 10;
        private int elapsed = 0;

        private KeyboardState keyboard;

        //public event EventHandler Pause;

        //public event EventHandler GameMute;

        //public event EventHandler GameRestart;

        public void ProcessUserInput()
        {
            this.keyboard = Keyboard.GetState();

            if (this.elapsed == 0)
            {
                //if (this.keyboard.IsKeyDown(Keys.P))
                //{
                //    if (this.Pause != null)
                //    {
                //        this.Pause(this, new EventArgs());
                //        this.elapsed++;
                //    }
                //}
                //else if (this.keyboard.IsKeyDown(Keys.M))
                //{
                //    if (this.GameMute != null)
                //    {
                //        this.GameMute(this, new EventArgs());
                //        this.elapsed++;
                //    }
                //}
                //else if (this.keyboard.IsKeyDown(Keys.Enter))
                //{
                //    if (this.GameRestart != null)
                //    {
                //        this.GameRestart(this, new EventArgs());
                //    }
                //}
            }

            if (0 < this.elapsed)
            {
                this.elapsed++;

                if (this.elapsed == Timeout)
                {
                    this.elapsed = 0;
                }
            }
        }
    }
}
