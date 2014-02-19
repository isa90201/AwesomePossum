using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RPG
{
    //Create an ENEMY using this class
    public class Character
    {
        private const int MIN_HP = 1;
        private const int MAX_HP = 100;
        private const int MIN_ATTACK = 1;
        private const int MAX_ATTACK = 100;
        private const int MIN_DEFENSE = 0;
        private const int MAX_DEFENSE = 100;
        private const int MIN_EXPERIENCE = 0;
        private const int MAX_EXPERIENCE = 100;
        private const int MIN_LEVEL = 1;
        private const int MAX_LEVEL = 100;

        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public Hitbox Hitbox { get; set; }

        [XmlIgnore]
        public IController Controller;

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
                else if (value >= MAX_EXPERIENCE)
                {
                    LevelUp();
                    Experience = value - MAX_EXPERIENCE;
                }
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
                if (Weapon != null)
                    return _Attack + Weapon.Attack;
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
                if (Armor != null)
                    return _Defense + Armor.Defense;
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

        public bool IsAlive()
        {
            return CurrentHP >= MIN_HP;
        }

        public Character(string name, int totalHP, int attack, int defense)
        {
            Name = name;
            TotalHP = totalHP;
            CurrentHP = TotalHP;
            Attack = attack;
            Defense = defense;
            Experience = MIN_EXPERIENCE;
            Level = MIN_LEVEL;

            Init();
        }

        public Character()
        {
            Init();
        }

        private void Init()
        {
            Weapon = Weapon.NULL;
            Armor = Armor.NULL;
            Hitbox = new Hitbox();
        }

        private void LevelUp()
        {
            Level++;
            Attack++;
            Defense++;
            TotalHP++;
            CurrentHP = TotalHP;
        }
    }
}
