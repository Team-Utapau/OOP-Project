using System;
using System.Windows.Forms;
using System.Xml;
using Utrepalo.Game.MenuItem;

namespace Utrepalo.Game
{
#if WINDOWS || XBOX
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //var controller = new KeyboardController();
            //using (GameEngine game = new GameEngine(controller))
            //{
            //    game.Run();
            //}
            var menu = new MainGameMenu();
            menu.ShowDialog();
        }
    }
#endif
}

