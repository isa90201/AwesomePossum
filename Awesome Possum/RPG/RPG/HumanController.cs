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

        Keys Up = Keys.Up,
            Down = Keys.Down,
            Left = Keys.Left,
            Right = Keys.Right,
            Attack = Keys.A,
            Jump = Keys.S,
            Pause = Keys.Space,
            Confirm = Keys.Enter,
            Cancel = Keys.Delete;

        public HumanController()
        {

        }

        public void GetInput()
        {
            CurrentState = Keyboard.GetState();
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

        public bool PauseIsPressed()
        {
            return CurrentState.IsKeyDown(Pause);
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
            return UpIsPressed();
        }

        public bool IsMovingDown()
        {
            return DownIsPressed();
        }

        public bool IsMovingLeft()
        {
            return LeftIsPressed();
        }

        public bool IsMovingRight()
        {
            return RightIsPressed();
        }

        public bool IsAttacking()
        {
            return AttackIsPressed();
        }

        public bool IsJumping()
        {
            return JumpIsPressed();
        }
    }
}
