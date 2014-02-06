using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class GameSave
    {
        public string WeaponName;
        public int WeaponAttack;
        public int WeaponExperience;

        public string ArmorName;
        public int ArmorDefense;
        public int ArmorExperience;

        public Weapon InventoryWeapon;
        public Weapon InventoryArmor;

        public string CharacterName;
        public int CharacterTotalHP;
        public int CharacterCurrentHP;
        public int CharacterAttack;
        public int CharacterDefense;
        public int CharacterExperience;
        public int CharacterLevel;

        public string LevelName;
        public int LevelId;

        public GameSave(Party party, Level currentLevel)
        {
            CharacterSave(party);
            WeaponSave(party);
            ArmorSave(party);
            LevelSave(currentLevel);
        }

        private void CharacterSave(Party party)
        {
            CharacterName = party.Character.Name;
            CharacterTotalHP = party.Character.TotalHP;
            CharacterCurrentHP = party.Character.CurrentHP;
            CharacterAttack = party.Character.Attack;
            CharacterDefense = party.Character.Defense;
            CharacterExperience = party.Character.Experience;
            CharacterLevel = party.Character.Level;
        }

        private void WeaponSave(Party party)
        {
            Weapon w = party.Inventory.EquippedWeapon;

            if (w == null)
            {
                WeaponName = null;
                WeaponAttack = -1;
            }
            else
            {
                WeaponName = w.Name;
                WeaponAttack = w.Attack;
            }
        }

        private void ArmorSave(Party party)
        {
            Armor a = party.Inventory.EquippedArmor;

            if (a == null)
            {
                ArmorName = null;
                ArmorDefense = -1;
            }
            else
            {
                ArmorName = a.Name;
                ArmorDefense = a.Defense;
            }
        }

        private void LevelSave(Level level)
        {
            LevelName = level.Name;
            LevelId = level.LevelId;
        }
    }
}
