using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class MusicJukebox
    {
        public Music[] MusicList { get; set; }

        public MusicJukebox(Music[] m)
        {
            MusicList = m;
        }
    }
}
