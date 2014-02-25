using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RPG
{
    public class MusicItem
    {
        public string FilePath { get; set; }

        public string FileName
        {
            get
            {
                return Path.GetFileName(FilePath);
            }
        }
    }
}
