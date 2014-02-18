using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class AIController : IController
    {
        private enum Direction { UP, DOWN, LEFT, RIGHT };
        private Direction HorizontalDirection;
        private Direction VerticalDirection;
        private bool Attacking;
        private EnemyAI Eai;

        public AIController(EnemyAI eai)
        {
            Eai = eai;
        }

        public void Move(Rectangle aiPlayer, Rectangle humanPlayer)
        {
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

        private void Attack(Rectangle aiPlayer, Rectangle humanPlayer)
        {
            if (Eai.IsAttacking())
            {
                Attacking = aiPlayer.Overlap(humanPlayer);
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
            return Attacking;
        }
    }
}
