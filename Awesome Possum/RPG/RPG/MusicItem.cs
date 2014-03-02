using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace RPG
{
    public class MusicItem
    {
        public string FilePath { get; set; }

        public string FileName
        {
            get
            {
                return Path.GetFileNameWithoutExtension(FilePath);
            }
        }

        public Uri SongURI()
        {
            var path = string.Format("file://{0}", FilePath.Replace('\\', '/'));
            return new Uri(path);
        }

        public Song GetSong()
        {
            return Song.FromUri(FileName, SongURI());
        }
    }
}
