using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Weapon
    {
        private const int MIN_ATTACK = 1;
        private const int MAX_ATTACK = 100;

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

        private int _Attack;
        public int Attack
        {
            get
            {
                return _Attack;
            }
            set
            {
                if (value < MIN_ATTACK)
                    _Attack = MIN_ATTACK;
                else if (value > MAX_ATTACK)
                    _Attack = MAX_ATTACK;
                else
                    _Attack = value;
            }
        }

        public Weapon() { }

        public Weapon(string name, int attack)
        {
            Name = name;
            Attack = attack;
        }

        public static Weapon NULL = new Weapon() { Name = "None", Attack = 0 };
    }
}
