using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Inventory
    {
        private const int INVENTORY_SIZE = 2;

        private Weapon _EquippedWeapon;
        public Weapon EquippedWeapon
        {
            get
            {
                return _EquippedWeapon;
            }
            set
            {
                _EquippedWeapon = value;
            }
        }

        private Armor[] _EquippedArmor;  // Change to LIST???
        public Armor[] EquippedArmor
        {
            get
            {
                return _EquippedArmor;
            }
            set
            {
                _EquippedArmor = value;
            }
        }

        private int _ArmorCount;
        public int ArmorCount
        {
            get
            {
                return _ArmorCount;
            }
            set
            {
                if (value < 0)
                    _ArmorCount = 0;
                else if (value > INVENTORY_SIZE)
                    _ArmorCount = INVENTORY_SIZE;
                else
                    _ArmorCount = value;
            }
        }

        public Inventory()
        {
            EquippedWeapon = null;
            EquippedArmor = new Armor[INVENTORY_SIZE];
            ArmorCount = 0;

            //Initialize all slots to EMPTY
            for (int i = 0; i < INVENTORY_SIZE; ++i)
            {
                EquippedArmor[i] = null;
            }
        }

        public bool InsertWeapon(Weapon weapon)
        {
            if (EquippedWeapon != null)
            {
                EquippedWeapon = weapon;
                return true;
            }
            return false;
        }

        public Armor GetArmorInSlot(int slotNumber)
        {
            return EquippedArmor[slotNumber];
        }

        public bool ArmorSlotIsEmpty(int slotNumber)
        {
            return EquippedArmor[slotNumber] == null;
        }

        public bool ArmorSlotsAreAllEmpty()
        {
            return ArmorCount == 0;
        }

        public bool ArmorSlotsAreAllFull()
        {
            return ArmorCount == INVENTORY_SIZE;
        }

        public bool InsertAmorIntoSlot(Armor armor, int slotNumber)
        {
            if (EquippedArmor[slotNumber] == null)
            {
                EquippedArmor[slotNumber] = armor;
                ArmorCount += 1;
                return true;
            }
            return false;
        }

        public bool RemoveArmorFromSlot(int slotNumber)
        {
            if (EquippedArmor[slotNumber] != null)
            {
                EquippedArmor[slotNumber] = null;
                ArmorCount -= 1;
                return true;
            }
            return false;
        }
    }
}
