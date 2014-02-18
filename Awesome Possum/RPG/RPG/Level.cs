using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RPG
{
    public class Level
    {
        [XmlElement("Background")]
        public List<Background> StageBackgrounds { get; set; }

        [XmlElement("Music")]
        public List<string> Music { get; set; }

        public Level()
        {
            StageBackgrounds = new List<Background>();
            Music = new List<string>();
        }
    }
}
