﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class AIController : IController
    {
        private enum Direction { NONE, UP, DOWN, LEFT, RIGHT };
        private Direction HorizontalDirection;
        private Direction VerticalDirection;
        private EnemyAI Eai;

        public Character Self { get; set; }
        public Character Enemy { get; set; }

        public AIController(EnemyAI eai)
        {
            Eai = eai;
        }

        public void Update()
        {
            Move(Self.Hitbox, Enemy.Hitbox);
        }

        public void Move(Hitbox aiPlayer, Hitbox humanPlayer)
        {
            VerticalDirection = Direction.NONE;
            HorizontalDirection = Direction.NONE;

            if (Eai.IsMoving())
            {
                //Vertical Check
                if (aiPlayer.Y > humanPlayer.Y)
                    VerticalDirection = Direction.UP;
                else if (aiPlayer.Y < humanPlayer.Y)
                    VerticalDirection = Direction.DOWN;

                //Horizontal Check
                if (aiPlayer.X > humanPlayer.X)
                    HorizontalDirection = Direction.LEFT;
                else if (aiPlayer.X < humanPlayer.X)
                    HorizontalDirection = Direction.RIGHT;
            }
        }

        public bool IsMovingUp()
        {
            return VerticalDirection == Direction.UP;
        }

        public bool IsMovingDown()
        {
            return VerticalDirection == Direction.DOWN;
        }

        public bool IsMovingLeft()
        {
            return HorizontalDirection == Direction.LEFT;
        }

        public bool IsMovingRight()
        {
            return HorizontalDirection == Direction.RIGHT;
        }

        public bool IsAttacking()
        {
            return Eai.IsAttacking();
        }

        public bool IsJumping()
        {
            return false;
        }

        public bool IsSwitchingWeapon()
        {
            return false;
        }
    }
}
