using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    //Create an ENEMY using this class
    public class CharacterBase
    {
        private const int MIN_HP = 1;
        private const int MAX_HP = 100;
        private const int MIN_ATTACK = 1;
        private const int MAX_ATTACK = 100;
        private const int MIN_DEFENSE = 0;
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
                if (value == "")
                    _Name = "UNKNOWN";
                else
                    _Name = value;
            }
        }

        private int _TotalHP;
        public int TotalHP
        {
            get
            {
                return _TotalHP;
            }
            set
            {
                if (value < MIN_HP)
                    _TotalHP = MIN_HP;
                else if (value > MAX_HP)
                    _TotalHP = MAX_HP;
                else
                    _TotalHP = value;
            }
        }

        private int _CurrentHP;
        public int CurrentHP
        {
            get
            {
                return _CurrentHP;
            }
            set
            {
                if (value < MIN_HP)
                    _CurrentHP = 0;
                else if (value > MAX_HP)
                    _CurrentHP = MAX_HP;
                else
                    _CurrentHP = value;
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

        public bool IsAlive
        {
            get
            {
                return CurrentHP >= MIN_HP;
            }
        }

        public CharacterBase(string name, int totalHP, int attack, int defense)
        {
            Name = name;
            TotalHP = totalHP;
            CurrentHP = TotalHP;
            Attack = attack;
            Defense = defense;
        }

        public void Damage(int amount)  // Use negative amount for HP Recovery.
        {
            CurrentHP -= amount;
        }
    }
}
