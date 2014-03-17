using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class EnemyAI
    {
        enum States
        {
            IDLE,
            WALKING
        }

        private const int UPPER_BOUND = 1000;            //random number generator

        private int DifficultyNumber;
        private Random RandomNumber;

        private int MinWalkTime;
        private int MaxWalkTime;

        private int MinWaitTime;
        private int MaxWaitTime;

        private int MinAttackTime;
        private int MaxAttackTime;

        private int WaitTime;
        private int AttackWaitTime;
        private States State;

        public EnemyAI(int ai_difficultyNumber, Random r)  //Assigned difficulty
        {
            DifficultyNumber = ai_difficultyNumber;
            RandomNumber = r;

            MaxWalkTime = ai_difficultyNumber * 40 + 1000;
            MinWalkTime = ai_difficultyNumber * 27 + 250;

            MaxWaitTime = ai_difficultyNumber * -25 + 3000;
            MinWaitTime = ai_difficultyNumber * -10 + 1000;

            MinAttackTime = ai_difficultyNumber * -5 + 1000;
            MaxAttackTime = ai_difficultyNumber * -40 + 5000;
        }

        public bool IsAttacking()
        {
            if (AttackWaitTime < Environment.TickCount)
            {
                AttackWaitTime = Environment.TickCount + RandomNumber.Next(MinAttackTime, MaxAttackTime);
                return true;
            }

            return false;
        }

        public bool IsMoving()
        {
             if (WaitTime < Environment.TickCount)
            {
                if (State == States.IDLE)
                {
                    State = States.WALKING;
                    WaitTime = Environment.TickCount + RandomNumber.Next(MinWalkTime, MaxWalkTime);
                }
                else
                {
                    State = States.IDLE;
                    WaitTime = Environment.TickCount + RandomNumber.Next(MinWaitTime, MaxWaitTime);
                }
            }

            return State == States.WALKING;
        }
    }
}
