namespace Utrepalo.Game
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main()
        {
            using (GameEngine game = new GameEngine())
            {
                game.Run();
            }
        }
    }
#endif
}

