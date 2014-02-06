using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Inventory
    {
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }

        public Inventory()
        {
            EquippedWeapon = null;
            EquippedArmor = null;
        }

        public bool EquipWeapon(Weapon weapon)
        {
            if (EquippedWeapon != null)
            {
                EquippedWeapon = weapon;
                return true;
            }
            return false;
        }

        public bool EquipArmor(Armor armor)
        {
            if (EquippedArmor != null)
            {
                EquippedArmor = armor;
                return true;
            }
            return false;
        }
    }
}
