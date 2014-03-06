using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Linq;

namespace RPG
{
    //Create an ENEMY using this class
    public class Character : IDrawable
    {
        public enum Directions
        {
            Left,
            Right
        }

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

        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }

        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }

        private Hitbox _Hitbox;
        public Hitbox Hitbox
        {
            get
            {
                if (_Hitbox == null)
                    _Hitbox = new Hitbox() { H = 200, W = 100 };

                _Hitbox.X = X;
                _Hitbox.Y = Y;
                return _Hitbox;
            }
            set
            {
                _Hitbox = value;
            }
        }

        private Hitbox _Attackbox;
        public Hitbox AttackBox
        {
            get
            {
                if (_Attackbox == null)
                    _Attackbox = new Hitbox() { H = 200, W = 100 };

                _Attackbox.X = X;
                _Attackbox.Y = Y;
                return _Attackbox;
            }
            set
            {
                _Attackbox = value;
            }
        }

        public SpriteCollection Sprites { get; set; }

        public SpriteAction.States State { get; set; }
        public SpriteAction.States PrevState { get; set; }

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
            State = SpriteAction.States.IDLE;
        }

        private void LevelUp()
        {
            Level++;
            Attack++;
            Defense++;
            TotalHP++;
            CurrentHP = TotalHP;
        }

        public void Move()
        {
            State = SpriteAction.States.IDLE;

            if (Controller.IsMovingUp())
            {
                Y -= Speed;
                State = SpriteAction.States.WALKING;
            }
            else if (Controller.IsMovingDown())
            {
                Y += Speed;
                State = SpriteAction.States.WALKING;
            }

            if (Controller.IsMovingLeft())
            {
                X -= Speed;
                Direction = Directions.Left;
                State = SpriteAction.States.WALKING;
            }
            else if (Controller.IsMovingRight())
            {
                X += Speed;
                Direction = Directions.Right;
                State = SpriteAction.States.WALKING;
            }
        }


        public Directions Direction { get; set; }
        private Directions PrevDirection;

        private AnimatedSprite CurrentSprite;
        public AnimatedSprite GetAnimatedSprite()
        {
            var sprite = Sprites.Actions.FirstOrDefault(s => s.Name == State);

            if (sprite != null)
            {
                if (CurrentSprite == null || PrevState != State || PrevDirection != Direction)
                    CurrentSprite = sprite.GetAnimatedSprite(Direction);

                CurrentSprite.X = X;
                CurrentSprite.Y = Y;

                PrevDirection = Direction;
                PrevState = State;
            }
            return CurrentSprite;
        }

        public Vector2 GetVector2D()
        {
            return new Vector2(X, Y);
        }
    }
}
