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

        public GameSave(Party party)
        {
            CharacterSave(party);
            WeaponSave(party);
            ArmorSave(party);
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
            WeaponName = w.Name;
            WeaponAttack = w.Attack;
        }

        private void ArmorSave(Party party)
        {
            Armor a = party.Inventory.EquippedArmor;
            ArmorName = a.Name;
            ArmorDefense = a.Defense;
        }

        private void SaveToFile()
        {
            //TODO:  save to file; read from file
        }
    }
}
