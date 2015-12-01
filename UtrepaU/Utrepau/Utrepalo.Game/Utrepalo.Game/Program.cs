using System.Xml;

namespace Utrepalo.Game
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main()
        {
            var controller = new KeyboardController();
            using (GameEngine game = new GameEngine(controller))
            {
                game.Run();
            }
        }
    }
#endif
}

