//#define EDITOR //uncomment to test the Level Editor

using System;
using System.Linq;
using RPG.Editor;

namespace RPG
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
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

            var window = new MainEditorWindow();
            window.ShowDialog();
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

