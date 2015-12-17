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


        public void ProcessUserInput()
        {
            this.keyboard = Keyboard.GetState();
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
