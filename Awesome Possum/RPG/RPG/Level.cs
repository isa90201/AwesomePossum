﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Level
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

        private int _LevelId;
        public int LevelId
        {
            get
            {
                return _LevelId;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Level ID must be 0 or greater.");
                _LevelId = value;
            }
        }
    }
}