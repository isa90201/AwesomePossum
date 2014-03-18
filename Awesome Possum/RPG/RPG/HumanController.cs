using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class HumanController : IController
    {
        public KeyboardState CurrentState;
        private bool HasSwitched;

        private bool HitSwitch;
        public bool DebugHitbox { get; set; }

        Keys Up = Keys.Up,
            Down = Keys.Down,
            Left = Keys.Left,
            Right = Keys.Right,
            Attack = Keys.A,
            Jump = Keys.S,
            SwitchWeapon = Keys.Space,
            Confirm = Keys.Enter,
            Cancel = Keys.Delete;

        public HumanController()
        {

        }

        public void Update()
        {
            CurrentState = Keyboard.GetState();

            if (CurrentState.IsKeyDown(Keys.F1))
            {
                if (!HitSwitch)
                    DebugHitbox = !DebugHitbox;

                HitSwitch = true;
            }
            else
            {
                HitSwitch = false;
            }
        }

        public bool UpIsPressed()
        {
            return CurrentState.IsKeyDown(Up);
        }

        public bool DownIsPressed()
        {
            return CurrentState.IsKeyDown(Down);
        }

        public bool LeftIsPressed()
        {
            return CurrentState.IsKeyDown(Left);
        }

        public bool RightIsPressed()
        {
            return CurrentState.IsKeyDown(Right);
        }

        public bool AttackIsPressed()
        {
            return CurrentState.IsKeyDown(Attack);
        }

        public bool JumpIsPressed()
        {
            return CurrentState.IsKeyDown(Jump);
        }

        public bool SwitchWeaponIsPressed()
        {
            if (CurrentState.IsKeyDown(SwitchWeapon))
            {
                var ret = !HasSwitched;
                HasSwitched = true;
                return ret;
            }
            else
            {
                HasSwitched = false;
                return false;
            }
        }

        public bool ConfirmIsPressed()
        {
            return CurrentState.IsKeyDown(Confirm);
        }

        public bool CancelIsPressed()
        {
            return CurrentState.IsKeyDown(Cancel);
        }

        public bool IsMovingUp()
        {
            return UpIsPressed() && !DownIsPressed();
        }

        public bool IsMovingDown()
        {
            return DownIsPressed() && !UpIsPressed();
        }

        public bool IsMovingLeft()
        {
            return LeftIsPressed() && !RightIsPressed();
        }

        public bool IsMovingRight()
        {
            return RightIsPressed() && !LeftIsPressed();
        }

        public bool IsAttacking()
        {
            return AttackIsPressed();
        }

        public bool IsJumping()
        {
            return JumpIsPressed();
        }

        public bool IsSwitchingWeapon()
        {
            return SwitchWeaponIsPressed();
        }
    }
}
