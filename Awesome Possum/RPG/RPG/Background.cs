using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RPG
{
    public class Background
    {
        public const int WIDTH = 1280;
        public const int HEIGHT = 800;

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
    }
}
