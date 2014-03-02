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

        public Background BackgroundImage { get; set; }

        public MusicItem Music { get; set; }

        public int TotalNumberOfBadGuys { get; set; }
        public int BadGuysOnScreen { get; set; }

        public Level()
        {
            BackgroundImage = new Background();
            Music = new MusicItem();
        }

        internal bool IsValid()
        {
            return !string.IsNullOrEmpty(BackgroundImage.FilePath) && !string.IsNullOrEmpty(Music.FilePath);
        }
    }
}
