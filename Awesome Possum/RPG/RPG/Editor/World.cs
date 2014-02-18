using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Editor
{
    public class World
    {
        public List<Level> Levels { get; set; }

        public World()
        {
            Levels = new List<Level>();
        }
    }
}
