using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RPG
{
    public class Level
    {
        public int Id { get; set; }

        [XmlElement("Background")]
        public List<Background> StageBackgrounds { get; set; }

        [XmlElement("Music")]
        public List<MusicItem> Music { get; set; }

        public int NumberOfBadGuys { get; set; }

        public Level()
        {
            StageBackgrounds = new List<Background>();
            Music = new List<MusicItem>();
        }
    }
}
