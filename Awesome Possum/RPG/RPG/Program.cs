using System;

namespace RPG
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (RPGgame game = new RPGgame())
            {
                game.Run();
            }
        }
    }
#endif
}

