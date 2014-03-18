using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public interface IController
    {
        bool IsMovingUp();
        bool IsMovingDown();
        bool IsMovingLeft();
        bool IsMovingRight();
        bool IsAttacking();
        bool IsJumping();
        void Update();
        bool IsSwitchingWeapon();
    }
}
