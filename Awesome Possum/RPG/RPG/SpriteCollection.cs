using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RPG
{
    public class SpriteCollection
    {
        public List<SpriteAction> Actions { get; set; }

        public static SpriteCollection CreateNew()
        {
            var col = new SpriteCollection();

            col.Actions.Add(new SpriteAction() { Name = SpriteAction.States.IDLE });
            col.Actions.Add(new SpriteAction() { Name = SpriteAction.States.WALKING });
            col.Actions.Add(new SpriteAction() { Name = SpriteAction.States.HURT });

            //col.Actions.Add(new SpriteAction() { Name = "Invincible" });
            //col.Actions.Add(new SpriteAction() { Name = "Attack" });
            //col.Actions.Add(new SpriteAction() { Name = "Die" });

            return col;
        }

        public SpriteCollection()
        {
            Actions = new List<SpriteAction>();
        }

        public bool Save(string path)
        {
            MakePathsRelative(SavePath(path));

            Serializer.Serialize(path, this);

            MakePathsAbsolute(SavePath(path));
            return true;
        }

        public static SpriteCollection Load(string path)
        {
            var world = Serializer.Deserialize(path, typeof(SpriteCollection)) as SpriteCollection;

            world.MakePathsAbsolute(SavePath(path));

            return world;
        }

        private static string SavePath(string filePath)
        {
            return Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath));
        }

        private void MakePathsAbsolute(string folder)
        {
            foreach (var action in Actions)
            {
                action.FilePath = action.FilePath.MakeAbsolute(folder, action.Id);
            }
        }

        private void MakePathsRelative(string folder)
        {
            int i = 0;

            foreach (var action in Actions)
            {
                action.Id = i++;
                action.FilePath = action.FilePath.MakeRelative(folder, "Sprite", action.Id);
            }
        }

        internal bool IsValid()
        {
            return Actions.All(a => !string.IsNullOrEmpty(a.FilePath));
        }
    }
}
