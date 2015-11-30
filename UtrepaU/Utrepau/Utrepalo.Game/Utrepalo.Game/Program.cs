namespace Utrepalo.Game
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main()
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
#endif
}

