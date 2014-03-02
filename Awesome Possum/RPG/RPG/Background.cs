using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public class Background
    {
        public int Width { get; set; }
        public int Height { get; set; }

        private string _FilePath;
        public string FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                if (value == "" || value == null)
                    throw new ArgumentException("File path cannot be blank or null.");
                else
                    _FilePath = value;
            }
        }

        public string FileName
        {
            get
            {
                return Path.GetFileName(FilePath);
            }
        }

        public Texture2D GetTexture2D(GraphicsDevice g)
        {
            return Texture2D.FromStream(g, File.OpenRead(FilePath));
        }
    }
}
