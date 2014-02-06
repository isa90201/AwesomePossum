using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    interface IController
    {
        bool IsMovingUp();
        bool IsMovingDown();
        bool IsMovingLeft();
        bool IsMovingRight();
        bool IsAttacking();
    }
}
