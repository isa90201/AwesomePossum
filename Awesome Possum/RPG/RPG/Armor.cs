using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Armor
    {
        private const int MIN_DEFENSE = 1;
        private const int MAX_DEFENSE = 100;

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

        private int _Defense;
        public int Defense
        {
            get
            {
                return _Defense;
            }
            set
            {
                if (value < MIN_DEFENSE)
                    _Defense = MIN_DEFENSE;
                else if (value > MAX_DEFENSE)
                    _Defense = MAX_DEFENSE;
                else
                    _Defense = value;
            }
        }

        public Armor(string name, int defense)
        {
            Name = name;
            Defense = defense;
        }
    }
}
