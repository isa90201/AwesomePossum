using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Background
    {
        private const int WIDTH = 1280;
        private const int HEIGHT = 800;

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (value == "" || value == null)
                    throw new ArgumentException("Name cannot be blank or null.");
                else
                    _Name = value;
            }
        }

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

        public Background(string name, string filePath)
        {
            FilePath = filePath;
        }

        public Background() { }
    }
}
