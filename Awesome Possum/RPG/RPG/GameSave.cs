using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class GameSave
    {
        private const string CHARACTER_FILEPATH = "C:\\Users\\Isaias\\Desktop\\Character.xml";
        private const string LEVEL_FILEPATH = "C:\\Users\\Isaias\\Desktop\\Level.xml";

        public GameSave()
        {

        }

        public void SaveCharacter(Character c)
        {
            object o = c;
            Serializer.Serialize(CHARACTER_FILEPATH, c);
        }

        public void SaveLevel(Level l)
        {
            object o = l;
            Serializer.Serialize(LEVEL_FILEPATH, l);
        }

        public Character GetSavedCharacter()
        {
            return Serializer.Deserialize(CHARACTER_FILEPATH, typeof(Character)) as Character;
        }

        public Level GetSavedLevel()
        {
            return Serializer.Deserialize(LEVEL_FILEPATH, typeof(Level)) as Level;
        }
    }
}
