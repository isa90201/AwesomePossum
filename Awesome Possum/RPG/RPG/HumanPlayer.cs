using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class HumanPlayer : CharacterBase
    {
        private const int MIN_EXPERIENCE = 0;
        private const int MAX_EXPERIENCE = 100;
        private const int MIN_LEVEL = 1;
        private const int MAX_LEVEL = 100;

        private int _Experience;
        public int Experience
        {
            get
            {
                return _Experience;
            }
            set
            {
                if (value < MIN_EXPERIENCE)
                    _Experience = MIN_EXPERIENCE;
                else if (value > MAX_EXPERIENCE)
                    _Experience = MAX_EXPERIENCE;
                else
                    _Experience = value;
            }
        }

        private int _Level;
        public int Level
        {
            get
            {
                return _Level;
            }
            set
            {
                if (value < MIN_LEVEL)
                    _Level = MIN_LEVEL;
                else if (value > MAX_LEVEL)
                    _Level = MAX_LEVEL;
                else
                    _Level = value;
            }
        }

        public HumanPlayer(string name, int totalHP, int attack, int defense)
            : base(name, totalHP, attack, defense)
        {
            Experience = MIN_EXPERIENCE;
            Level = MIN_LEVEL;
        }

        public void GainExperience(int amount)
        {
            Experience += amount;
        }

        public void LevelUp(int amount)
        {
            Level += amount;
        }
    }
}
