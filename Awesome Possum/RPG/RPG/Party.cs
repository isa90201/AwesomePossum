using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Party
    {
        public Character Character { get; set; }
        public Inventory Inventory { get; set; }

        public Party(Character character, Inventory inventory)
        {
            Character = character;
            Inventory = inventory;
        }
    }
}
