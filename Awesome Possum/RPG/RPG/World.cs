using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RPG
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
            foreach (var level in Levels)
            {
                    level.Music.FilePath = level.Music.FilePath.MakeAbsolute(folder, level.Id);
                    level.BackgroundImage.FilePath = level.BackgroundImage.FilePath.MakeAbsolute(folder, level.Id);

            }
        }

        private void MakePathsRelative(string folder)
        {
            int i = 0;

            foreach (var level in Levels)
            {
                level.Id = i++;

                level.Music.FilePath = level.Music.FilePath.MakeRelative(folder, "Music", level.Id);
                level.BackgroundImage.FilePath = level.BackgroundImage.FilePath.MakeRelative(folder, "Background", level.Id);
            }
        }

        public bool Save(string path)
        {
            MakePathsRelative(SavePath(path));

            Serializer.Serialize(path, this);

            MakePathsAbsolute(SavePath(path));
            return true;
        }

        public static World Load(string path)
        {
            var world = Serializer.Deserialize(path, typeof(World)) as World;

            world.MakePathsAbsolute(SavePath(path));

            return world;
        }

        private static string SavePath(string filePath)
        {
            return Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath));
        }

        internal bool IsValid()
        {
            return Levels.All(l => l.IsValid());
        }
    }
}
