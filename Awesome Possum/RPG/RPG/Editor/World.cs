using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RPG.Editor
{
    public class World
    {
        public List<Level> Levels { get; set; }

        public World()
        {
            Levels = new List<Level>();
        }

        private void MakePathsAbsolute(string folder)
        {
            // TODO: make all paths in the world, levels, etc absolute and relative to "folder"
        }

        public bool Save(string path)
        {
            // TODO: make paths relative to "path", if any file doesn't exist, copy it

            Serializer.Serialize(path, this);

            MakePathsAbsolute(Path.GetDirectoryName(path));
            return true;
        }

        public static World Load(string path)
        {
            var world = Serializer.Deserialize(path, typeof(World)) as World;

            world.MakePathsAbsolute(Path.GetDirectoryName(path));

            return world;
        }
    }
}
