using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RPG
{
    class GameSaveXmlWriter
    {
        private const string FILE_PATH = "C:\\GameSave.xml";  // CHANGE TO ANY PATH
        private const string XML_HEADER = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

        private StringBuilder xmlString;
        private StreamWriter sw;

        public GameSaveXmlWriter(GameSave g)
        {
            xmlString = new StringBuilder("");
            sw = new StreamWriter(FILE_PATH, false);
            SaveToFile(g);

        }

        public void AddCharacterXML(string name, int totalHp, int currentHp, int attack, int defense, int experience, int level)
        {
            xmlString.AppendLine("<CHARACTER>");
            xmlString.AppendLine("<NAME>" + name + "</NAME>");
            xmlString.AppendLine("<TOTALHP>" + totalHp + "</TOTALHP>");
            xmlString.AppendLine("<CURRENTHP>" + currentHp + "</CURRENTHP>");
            xmlString.AppendLine("<ATTACK>" + attack + "</ATTACK>");
            xmlString.AppendLine("<DEFENSE>" + defense + "</DEFENSE>");
            xmlString.AppendLine("<EXPERIENCE>" + experience + "</EXPERIENCE>");
            xmlString.AppendLine("<LEVEL>" + level + "</LEVEL>");
            xmlString.AppendLine("</CHARACTER>");
        }

        public void AddWeaponXML(string name, int attack)
        {
            if (name == null)
                AddNoWeaponXML();
            else
            {
                xmlString.AppendLine("<WEAPON>");
                xmlString.AppendLine("<NAME>" + name + "</NAME>");
                xmlString.AppendLine("<ATTACK>" + attack + "</ATTACK>");
                xmlString.AppendLine("</WEAPON>");
            }
        }

        private void AddNoWeaponXML()
        {
            xmlString.AppendLine("<WEAPON></WEAPON>");
        }

        public void AddArmorXML(string name, int defense)
        {
            if (name == null)
                AddNoArmorXML();
            else
            {
                xmlString.AppendLine("<ARMOR>");
                xmlString.AppendLine("<NAME>" + name + "</NAME>");
                xmlString.AppendLine("<DEFENSE>" + defense + "</DEFENSE>");
                xmlString.AppendLine("</ARMOR>");
            }
        }

        private void AddNoArmorXML()
        {
            xmlString.AppendLine("<ARMOR></ARMOR>");
        }

        public void AddLevelXML(string name, int levelId)
        {
            xmlString.AppendLine("<LEVEL>");
            xmlString.AppendLine("<NAME>" + name + "</NAME>");
            xmlString.AppendLine("<LEVELID>" + levelId + "</LEVELID>");
            xmlString.AppendLine("</LEVEL>");
        }

        public void SaveToFile(GameSave g)
        {
            xmlString.AppendLine(XML_HEADER);
            AddCharacterXML(g.CharacterName, g.CharacterTotalHP, g.CharacterCurrentHP, g.CharacterAttack, g.CharacterDefense, g.CharacterExperience, g.CharacterLevel);
            AddWeaponXML(g.WeaponName, g.WeaponAttack);
            AddArmorXML(g.ArmorName, g.ArmorDefense);
            AddLevelXML(g.LevelName, g.LevelId);
            sw.Write(xmlString.ToString());
            sw.Close();

        }
    }
}
