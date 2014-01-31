using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Party
    {
        private HumanPlayer _HumanPlayer;
        public HumanPlayer HumanPlayer
        {
            get
            {
                return _HumanPlayer;
            }
            set
            {
                _HumanPlayer = value;
            }
        }

        private Inventory _Inventory;
        public Inventory Inventory
        {
            get
            {
                return _Inventory;
            }
            set
            {
                _Inventory = value;
            }
        }

        public Party(HumanPlayer humanPlayer, Inventory inventory)
        {
            HumanPlayer = humanPlayer;
            Inventory = inventory;
        }
    }
}
