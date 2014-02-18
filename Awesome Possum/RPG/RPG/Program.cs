//#define EDITOR //uncomment to test the Level Editor

using System;
using System.Linq;

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
            if (args.Any(a => a == "-l") || ForceEditor())
                LevelEditorMain();
            else
                GameMain();
        }

        static void GameMain()
        {
            using (RPGgame game = new RPGgame())
            {
                game.Run();
            }
        }

        static void LevelEditorMain()
        {
            // TODO Level Editor
        }

        static bool ForceEditor()
        {
#if EDITOR
            return true;
#else
            return false;
#endif
        }
    }
#endif
}

