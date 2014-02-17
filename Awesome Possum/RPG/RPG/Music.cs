using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Music
    {
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

        public Music(string name, string filePath)
        {
            Name = name;
            FilePath = filePath;
        }
    }
}
