using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RPG
{
    class GameSaveXmlWriter
    {
        private const string FILE_PATH = "C:\\GameSaveXML.txt";
        private const string XML_HEADER = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

        private StringBuilder xmlString;
        private StreamWriter sw;

        public GameSaveXmlWriter(GameSave g)
        {
            xmlString = new StringBuilder("");

            AddCharacterXML(g.CharacterName, g.CharacterTotalHP, g.CharacterCurrentHP, g.CharacterAttack, g.CharacterDefense, g.CharacterExperience, g.CharacterLevel);
            AddWeaponXML(g.WeaponName, g.WeaponAttack);
            AddArmorXML(g.ArmorName, g.ArmorDefense);
            sw.Write(xmlString.ToString());
            //TODO: write to file

        }

        public void AddCharacterXML(string name, int totalHp, int currentHp, int attack, int defense, int experience, int level)
        {
            xmlString.AppendLine("<Character>");
            xmlString.AppendLine("<NAME>" + name + "</NAME>");
            xmlString.AppendLine("<TOTALHP>" + totalHp + "</TOTALHP>");
            xmlString.AppendLine("<CURRENTHP>" + currentHp + "</CURRENTHP>");
            xmlString.AppendLine("<ATTACK>" + attack + "</ATTACK>");
            xmlString.AppendLine("<DEFENSE>" + defense + "</DEFENSE>");
            xmlString.AppendLine("<EXPERIENCE>" + experience + "</EXPERIENCE>");
            xmlString.AppendLine("<LEVEL>" + level + "</LEVEL>");
            xmlString.AppendLine("</Character>");
        }

        public void AddWeaponXML(string name, int attack)
        {
            xmlString.AppendLine("<WEAPON>");
            xmlString.AppendLine("<NAME>" + name + "</NAME>");
            xmlString.AppendLine("<ATTACK>" + attack + "</ATTACK>");
            xmlString.AppendLine("</WEAPON>");
        }

        public void AddArmorXML(string name, int defense)
        {
            xmlString.AppendLine("<ARMOR>");
            xmlString.AppendLine("<NAME>" + name + "</NAME>");
            xmlString.AppendLine("<DEFENSE>" + defense + "</DEFENSE>");
            xmlString.AppendLine("</ARMOR>");
        }
    }
}
