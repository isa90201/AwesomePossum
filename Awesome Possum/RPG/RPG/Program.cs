//#define LEVEL_EDITOR //uncomment to test the Level Editor
//#define CHARACTER_EDITOR //uncomment to test the Character Editor

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
            if (args.Any(a => a == "-l") || ForceLevelEditor())
                LevelEditorMain();
            else if (args.Any(a => a == "-c") || ForceCharacterEditor())
                CharacterEditorMain();
            else
                GameMain();
        }

        private static void CharacterEditorMain()
        {
            var window = new CharacterEditorWindow();
            window.ShowDialog();
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
            var window = new LevelEditorWindow();
            window.ShowDialog();
        }

        static bool ForceLevelEditor()
        {
#if LEVEL_EDITOR
            return true;
#else
            return false;
#endif
        }

        static bool ForceCharacterEditor()
        {
#if CHARACTER_EDITOR
            return true;
#else
            return false;
#endif
        }
    }
#endif
}

